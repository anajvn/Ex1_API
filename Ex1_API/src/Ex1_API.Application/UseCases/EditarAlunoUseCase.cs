using Ex1_API.Application.Inputs;
using Ex1_API.Application.Interfaces.Repositories;
using Ex1_API.Application.Outputs;
using Ex1_API.Core;
using System.Net;
using Ex1_API.Application.Interfaces;

namespace Ex1_API.Application.UseCases
{
    public class EditarAlunoUseCase : IEditarAlunoUseCase
    {
        private readonly IAlunoRepository _alunoRepository;
        public EditarAlunoUseCase(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public UseCaseOutput Execute(EditarAlunoInput input)
        {
            var aluno = new Aluno
            (
                input.Id,
                input.Nome,
                input.Cidade,
                input.Idade
            );

            // Chama o banco de dados:
            // Ver se o aluno existe aluno, se existir, salvar;
            var result = _alunoRepository.Editar(aluno);

            if(!result)
            {
                aluno.Validations.Add("O aluno não foi encontrado.");
                return new UseCaseOutput(aluno.Validations);
            }

            return new UseCaseOutput(new AlunoPresenter(aluno));
        }
    }
}
