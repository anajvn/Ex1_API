﻿using Ex1_API.Core;

namespace Ex1_API.Application.Interfaces.Repositories
{
    public interface IAlunoRepository
    {
        void Adicionar(Aluno aluno);

        bool Editar(Aluno aluno);

        List<Aluno> BuscarTodos();

        Aluno BuscarPorId(Guid id);

        bool DeletarAluno(Guid id);
    }
}
