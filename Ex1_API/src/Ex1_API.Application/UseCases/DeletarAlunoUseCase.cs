using System.Net;
using Ex1_API.Application.Inputs;
using Ex1_API.Application.Interfaces;
using Ex1_API.Application.Interfaces.Repositories;
using Ex1_API.Application.Outputs;
using Ex1_API.Core;

namespace Ex1_API.Application.UseCases
{
    public class DeletarAlunoUseCase : IDeletarAlunoUseCase
    {
        private readonly IAlunoRepository _alunoRepository;

        public DeletarAlunoUseCase(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }
        public UseCaseOutput Execute(Guid id)
        {
            var result = _alunoRepository.DeletarAluno(id);

            if (!result)
                return new UseCaseOutput(new List<string>(){ "O aluno não foi encontrado." });

            return new UseCaseOutput()
            {
                Code = HttpStatusCode.NoContent
            };
        }
    }
}
