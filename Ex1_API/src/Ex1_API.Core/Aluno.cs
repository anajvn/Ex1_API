namespace Ex1_API.Core
{
    public class Aluno : BaseEntity
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Cidade { get; private set; }
        public int? Idade { get; private set; }

        public Aluno(string nome, string cidade, int? idade) : base()
        {
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

            IsValid = !Validations.Any();
        }
    }
}