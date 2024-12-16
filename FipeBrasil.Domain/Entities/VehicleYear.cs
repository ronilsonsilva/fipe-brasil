namespace FipeBrasil.Domain.Entities
{
    public class VehicleYear : BaseEntity
    {
        public string Code { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public Guid ModelId { get; private set; }
        public Model Model { get; private set; } = null!;

        public VehicleYear(string code, string name, Guid modelId)
        {
            Code = code;
            Name = name;
            ModelId = modelId;
        }

        public VehicleYear SetCode(string code)
        {
            Code = code;
            return this;
        }

        public VehicleYear SetName(string name)
        {
            Name = name;
            return this;
        }
    }
}
