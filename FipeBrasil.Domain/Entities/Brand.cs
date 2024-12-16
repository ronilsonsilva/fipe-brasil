namespace FipeBrasil.Domain.Entities
{
    public class Brand : BaseEntity
    {
        public string Code { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public ICollection<Model> Models { get; set; } = new List<Model>();

        public Brand(string code, string name)
        {
            Code = code;
            Name = name;
        }

        public Brand SetCode(string code)
        {
            Code = code;
            return this;
        }

        public Brand SetName(string name)
        {
            Name = name;
            return this;
        }
    }
}
