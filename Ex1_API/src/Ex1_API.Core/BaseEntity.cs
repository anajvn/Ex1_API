namespace Ex1_API.Core
{
    public class BaseEntity
    {
        public List<string> Validations { get; set; }
        public bool IsValid { get; set; }

            public BaseEntity()
        {
            Validations = new List<string>();
        }
    }
}
