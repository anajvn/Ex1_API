using Ex1_API.Core;

namespace Ex1_API.Application.Outputs
{
    public class AlunosPresenter
    {
        public List<AlunoPresenter> Dados { get; set; }

        public AlunosPresenter(List<Aluno> alunos)
        {
            foreach (var aluno in alunos)
            {
                Dados.Add(new AlunoPresenter(aluno));
            }
        }
    }
}
