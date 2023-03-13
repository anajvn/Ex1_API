namespace Ex1_API.Core
{
    public class Aluno : BaseEntity
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public int? Idade { get; set; }

        public Aluno(string nome, string cidade, int? idade) : base()
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Cidade = cidade;
            Idade = idade;

            this.Validate();
        }

        private void Validate()
        {
            if (String.IsNullOrWhiteSpace(this.Nome))
            {
                Validations.Add($"{nameof(Nome)} não pode estar vazio");
            }
            if (String.IsNullOrWhiteSpace(this.Cidade))
            {
                Validations.Add($"{nameof(Cidade)} não pode estar vazio");
            }
        }
    }
}