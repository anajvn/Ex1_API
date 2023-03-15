using Ex1_API.Application.Interfaces;
using Ex1_API.Application.Interfaces.Repositories;
using Ex1_API.Application.Outputs;
using Ex1_API.Core;

namespace Ex1_API.Application.UseCases
{
    public class BuscarAlunoUseCase : IBuscarAlunoUseCase
    {
        private readonly IAlunoRepository _repository;

        public BuscarAlunoUseCase(IAlunoRepository repository)
        {
            _repository = repository;
        }

        public UseCaseOutput Execute(Guid id)
        {
            var aluno = _repository.BuscarPorId(id);

            if (aluno == null)
            {
                aluno.Validations.Add("O aluno ainda não está registrado.");
                return new UseCaseOutput(aluno.Validations);
            }

            return new UseCaseOutput(new AlunoPresenter(aluno));
        }
    }
}
