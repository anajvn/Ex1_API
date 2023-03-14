using Ex1_API.Application.Inputs;
using Ex1_API.Application.Outputs;
using Ex1_API.Core;
using System.Net;

namespace Ex1_API.Application.UseCases
{
    public class EditarAlunoUseCase
    {
        public EditarAlunoUseCase()
        {
        }

        public UseCaseOutput Execute(Guid id, EditarAlunoInput input)
        {
            var aluno = new Aluno
            (
                input.Nome,
                input.Cidade,
                input.Idade
            );

            if (!aluno.IsValid)
            {
                return new UseCaseOutput(aluno.Validations);
            }

            // Chama o banco de dados:
            //íf já existe esse aluno...

            //se não, salva aluno:
            return new UseCaseOutput(new AlunoPresenter(aluno));
        }
    }
}
