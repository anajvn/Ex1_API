namespace Ex1_API.Application.Inputs
{
    public class CadastrarAlunoInput
    {
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public int? Idade { get; set; }

        public CadastrarAlunoInput()
        {
            
        }
    }
}
