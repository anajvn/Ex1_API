namespace Ex1_API.Application.Inputs
{
    public class EditarAlunoInput
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public int? Idade { get; set; }

        public EditarAlunoInput()
        {
            
        }
    }
}
