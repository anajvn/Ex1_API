using Ex1_API.Application.Inputs;

namespace Ex1_API.Application.Interfaces
{
    public interface IDeletarAlunoUseCase
    {
        UseCaseOutput Execute(Guid id);
    }
}
