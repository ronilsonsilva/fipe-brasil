using FipeBrasil.Jobs.Models;
using Refit;

namespace FipeBrasil.Jobs
{
    public interface IFipeApi
    {
        [Get("/fipe/api/v1/{type}/marcas")]
        Task<List<BrandExternalResponse>> GetBrandsAsync(string type);

        [Get("/fipe/api/v1/{type}/marcas/{brandCode}/modelos")]
        Task<ModelsExternalResponse> GetModelsAsync(string type, int brandCode);

        [Get("/fipe/api/v1/{type}/marcas/{brandCode}/modelos/{modelCode}/anos")]
        Task<List<VehicleYearExternalResponse>> GetVehicleYearsAsync(string type, string brandCode, int modelCode);

        [Get("/fipe/api/v1/{type}/marcas/{brandCode}/modelos/{modelCode}/anos/{yearCode}")]
        Task<VehicleExternalResponse> GetVehicleAsync(string type, string brandCode, int modelCode, string yearCode);
    }
}


