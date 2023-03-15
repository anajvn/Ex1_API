using Ex1_API.Core;

namespace Ex1_API.Application.Interfaces.Repositories
{
    public interface IAlunoRepository
    {
        void Adicionar(Aluno aluno);

        bool Editar(Aluno aluno);

    }
}
