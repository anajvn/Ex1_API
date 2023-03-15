using System.Net;
using Ex1_API.Application.Interfaces;
using Ex1_API.Application.Interfaces.Repositories;
using Ex1_API.Application.Outputs;
using Ex1_API.Core;

namespace Ex1_API.Application.UseCases
{
    public class BuscarAlunosUseCase : IBuscarAlunosUseCase
    {
        private readonly IAlunoRepository _repository;

        public BuscarAlunosUseCase(IAlunoRepository repository)
        {
            _repository = repository;
        }
        public UseCaseOutput Execute()
        {
            var alunos = _repository.BuscarTodos();

            return new UseCaseOutput(new AlunosPresenter(alunos));
        }
    }
}
