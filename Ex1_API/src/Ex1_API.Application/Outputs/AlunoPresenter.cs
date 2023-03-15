using Ex1_API.Core;

namespace Ex1_API.Application.Outputs
{
    public class AlunoPresenter
    {
        public string Dados { get; set; }

        public AlunoPresenter(Aluno aluno)
        {
            Dados = $"Id: {aluno.Id} - Nome: {aluno.Nome} - Cidade: {aluno.Cidade}";

            if (aluno.Idade != null)
            {
                Dados += $" - Idade: {aluno.Idade}";
            }
        }
    }
}
