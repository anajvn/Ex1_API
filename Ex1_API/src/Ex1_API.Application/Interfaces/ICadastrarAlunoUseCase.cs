using Ex1_API.Application.Inputs;

namespace Ex1_API.Application.Interfaces
{
    public interface ICadastrarAlunoUseCase
    {
        UseCaseOutput Execute(CadastrarAlunoInput input);
    }
}
