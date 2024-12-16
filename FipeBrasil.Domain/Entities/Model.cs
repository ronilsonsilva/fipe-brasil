namespace FipeBrasil.Domain.Entities
{
    public class Model : BaseEntity
    {
        public int Code { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public Guid BrandId { get; private set; }
        public Brand Brand { get; private set; } = null!;
        public ICollection<VehicleYear> Years { get; private set; } = new List<VehicleYear>();

        public Model(int code, string name, Guid brandId)
        {
            Code = code;
            Name = name;
            BrandId = brandId;
        }

        public Model SetCode(int code)
        {
            Code = code;
            return this;
        }

        public Model SetName(string name)
        {
            Name = name;
            return this;
        }
    }
}
