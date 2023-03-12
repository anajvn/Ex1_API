using Ex1_API.Application.Inputs;
using Ex1_API.Application.Interfaces;
using Ex1_API.Application.Output;
using Ex1_API.Core;

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
                input.Id,
                input.Nome,
                input.Cidade
            );

            if (!aluno.IsValid)
            {
                return new UseCaseOutput(aluno.Validations);
            }

            // chama o banco de dados e faz o cadastro

            return new UseCaseOutput(new AlunoPresenter(aluno));
        }
    }
}
