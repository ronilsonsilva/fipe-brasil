using FipeBrasil.Application.DTOs;

namespace FipeBrasil.Application.Brand.Queries
{
    public class GetBrandsQueryResult
    {
        public GetBrandsQueryResult(IEnumerable<BrandDto> brands, int counts)
        {
            Brands = brands;
            Counts = counts;
        }

        public IEnumerable<BrandDto> Brands { get; set; }
        public int Counts { get; set; }
    }
}
