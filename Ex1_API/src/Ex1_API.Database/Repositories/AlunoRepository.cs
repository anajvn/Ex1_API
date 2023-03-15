using Ex1_API.Application.Interfaces.Repositories;
using Ex1_API.Core;

namespace Ex1_API.Database.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        //private readonly Connection _connection;
        //public AlunoRepository(Connection connection)
        //{
        //    _connection = connection;
        //}
        //public void Adicionar(Aluno aluno)
        //{
        //    using (var command = _connection.CreateCommand())
        //    {
        //        command.CommandText = "INSERT INTO Aluno (Nome, Cidade, Idade)" +
        //                              $"VALUES ({aluno.Nome}, {aluno.Cidade}, {aluno.Idade})";
                
        //        command.ExecuteNonQuery();
        //    }
        //}

        private readonly List<Aluno> _alunos;

        public void Adicionar(Aluno aluno)
        {
            _alunos.Add(aluno);
        }

        public bool Editar(Aluno aluno)
        {
            var index = _alunos.FindIndex(a => a.Id == aluno.Id);
            
            if(index == -1)
                return false;
            
            _alunos[index] = aluno;
            return true;
        }

        public List<Aluno> BuscarTodos()
        {
            return _alunos;
        }

        public Aluno? BuscarPorId(Guid id)
        {
            return _alunos.FirstOrDefault(a => a.Id == id);
        }

        public bool DeletarAluno(Guid id)
        {
            var aluno = _alunos.FirstOrDefault(a => a.Id == id);

            return _alunos.Remove(aluno);
        }
    }
}
