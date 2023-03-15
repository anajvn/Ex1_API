namespace Ex1_API.Application.Interfaces
{
    public interface IBuscarAlunoUseCase
    {
        UseCaseOutput Execute(Guid id);
    }
}
