namespace FipeBrasil.Domain.Entities
{
    public class Vehicle : BaseEntity
    {
        public VehicleType VehicleType { get; private set; }
        public string Price { get; private set; } = string.Empty;
        public string BrandName { get; private set; } = string.Empty;
        public string ModelName { get; private set; } = string.Empty;
        public int ModelYear { get; private set; }
        public string FuelType { get; private set; } = string.Empty;
        public string FipeCode { get; private set; } = string.Empty;
        public string ReferenceMonth { get; private set; } = string.Empty;
        public string FuelAbbreviation { get; private set; } = string.Empty;
        public Guid ModelId { get; private set; }
        public Model ModelEntity { get; private set; } = null!;

        public Vehicle(VehicleType vehicleType, string price, string brandName, string modelName, int modelYear, string fuelType, string fipeCode, string referenceMonth, string fuelAbbreviation, Guid modelId)
        {
            VehicleType = vehicleType;
            Price = price;
            BrandName = brandName;
            ModelName = modelName;
            ModelYear = modelYear;
            FuelType = fuelType;
            FipeCode = fipeCode;
            ReferenceMonth = referenceMonth;
            FuelAbbreviation = fuelAbbreviation;
            ModelId = modelId;
        }

        public Vehicle SetVehicleType(VehicleType vehicleType)
        {
            VehicleType = vehicleType;
            return this;
        }

        public Vehicle SetPrice(string price)
        {
            Price = price;
            return this;
        }

        public Vehicle SetBrandName(string brandName)
        {
            BrandName = brandName;
            return this;
        }

        public Vehicle SetModelName(string modelName)
        {
            ModelName = modelName;
            return this;
        }

        public Vehicle SetModelYear(int modelYear)
        {
            ModelYear = modelYear;
            return this;
        }

        public Vehicle SetFuelType(string fuelType)
        {
            FuelType = fuelType;
            return this;
        }

        public Vehicle SetFipeCode(string fipeCode)
        {
            FipeCode = fipeCode;
            return this;
        }

        public Vehicle SetReferenceMonth(string referenceMonth)
        {
            ReferenceMonth = referenceMonth;
            return this;
        }

        public Vehicle SetFuelAbbreviation(string fuelAbbreviation)
        {
            FuelAbbreviation = fuelAbbreviation;
            return this;
        }
    }
}
