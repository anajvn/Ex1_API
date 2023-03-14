using Ex1_API.Application.Inputs;
using Ex1_API.Application.Interfaces;
using Ex1_API.Application.Outputs;
using Ex1_API.Core;
using System.Net;

namespace Ex1_API.Application.UseCases
{
    public class CadastrarAlunoUseCase : ICadastrarAlunoUseCase
    {
        public CadastrarAlunoUseCase()
        {
        }
        public UseCaseOutput Execute(CadastrarAlunoInput input)
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
