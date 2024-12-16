using FipeBrasil.Domain.Entities;
using FipeBrasil.Infrastructure.Data.Context;

namespace FipeBrasil.Jobs
{
    public class UpsertDataJob
    {
        private readonly FipeDbContext _context;
        private readonly IFipeApi _fipeApi;

        public UpsertDataJob(FipeDbContext context, IFipeApi fipeApi)
        {
            _context = context;
            _fipeApi = fipeApi;
        }

        public async Task Execute()
        {
            Console.WriteLine("Executing data upsert...");

            // Sincronizar todos os tipos de veículos
            await SyncBrandsAndDetails("carros");
            await SyncBrandsAndDetails("motos");
            await SyncBrandsAndDetails("caminhoes");
        }

        private async Task SyncBrandsAndDetails(string type)
        {
            // Buscar e sincronizar marcas
            var brands = await _fipeApi.GetBrandsAsync(type);
            var existingBrands = _context.Brands.Select(b => new { b.Code, b.Id }).ToHashSet();
            var existingCodes = existingBrands.Select(b => b.Code).ToHashSet();

            var newBrands = brands
                .Where(brand => !existingCodes.Contains(brand.Codigo))
                .Select(brand => new Brand(brand.Codigo, brand.Nome))
                .ToList();

            if (newBrands.Any())
            {
                _context.Brands.AddRange(newBrands);
                await _context.SaveChangesAsync();
            }

            // Sincronizar detalhes de cada marca
            foreach (var brand in brands)
            {
                var currentBrand = existingBrands.FirstOrDefault(b => b.Code == brand.Codigo);
                if (currentBrand == null)
                    currentBrand = newBrands.Select(b => new { b.Code, b.Id }).FirstOrDefault(b => b.Code == brand.Codigo);

                if (currentBrand != null)
                    await SyncModelsAndDetails(type, brand.Codigo, currentBrand.Id);
            }
        }

        private async Task SyncModelsAndDetails(string type, string brandCode, Guid brandId)
        {
            // Buscar e sincronizar modelos
            var response = await _fipeApi.GetModelsAsync(type, int.Parse(brandCode));
            var existingModels = _context.Models.Select(m => new { m.Code, m.Id }).ToHashSet();
            var existingCodes = existingModels.Select(m => m.Code).ToHashSet();

            var newModels = response.Modelos
                .Where(model => !existingCodes.Contains(model.Codigo))
                .Select(model => new Model(model.Codigo, model.Nome, brandId))
                .ToList();

            if (newModels.Any())
            {
                _context.Models.AddRange(newModels);
                await _context.SaveChangesAsync();
            }

            // Sincronizar detalhes de cada modelo
            foreach (var model in response.Modelos)
            {
                var currentModel = existingModels.FirstOrDefault(m => m.Code == model.Codigo);
                if (currentModel == null)
                    currentModel = newModels.Select(m => new { m.Code, m.Id }).FirstOrDefault(m => m.Code == model.Codigo);

                if (currentModel != null)
                    await SyncVehicleYearsAndDetails(type, brandCode.ToString(), model.Codigo, currentModel.Id);
            }
        }

        private async Task SyncVehicleYearsAndDetails(string type, string brandCode, int modelCode, Guid modelId)
        {
            // Buscar e sincronizar anos de veículos
            var years = await _fipeApi.GetVehicleYearsAsync(type, brandCode, modelCode);
            var existingCodes = _context.VehicleYears.Select(vy => vy.Code).ToHashSet();

            var newYears = years
                .Where(year => !existingCodes.Contains(year.Codigo))
                .Select(year => new VehicleYear(year.Codigo, year.Nome, modelId))
                .ToList();

            if (newYears.Any())
            {
                _context.VehicleYears.AddRange(newYears);
                await _context.SaveChangesAsync();
            }

            // Sincronizar detalhes de cada ano de veículo
            foreach (var year in years)
            {
                await SyncVehicle(type, brandCode, modelCode, year.Codigo, modelId);
            }
        }

        private async Task SyncVehicle(string type, string brandCode, int modelCode, string yearCode, Guid modelId)
        {
            var vehicle = await _fipeApi.GetVehicleAsync(type, brandCode, modelCode, yearCode);
            var vehicleType = (VehicleType)Enum.Parse(typeof(VehicleType), type, true);

            if (vehicle != null && !_context.Vehicles.Any(v => v.FipeCode == vehicle.CodigoFipe && v.ModelYear == vehicle.AnoModelo && v.ModelName == vehicle.Modelo && v.ReferenceMonth == vehicle.MesReferencia))
            {
                var newVehicle = new Vehicle(
                    vehicleType,
                    vehicle.Valor,
                    vehicle.Marca,
                    vehicle.Modelo,
                    vehicle.AnoModelo,
                    vehicle.Combustivel,
                    vehicle.CodigoFipe,
                    vehicle.MesReferencia,
                    vehicle.SiglaCombustivel,
                    modelId
                );

                _context.Vehicles.Add(newVehicle);
                await _context.SaveChangesAsync();
            }
        }
    }

}


