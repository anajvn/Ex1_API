using Ex1_API.Application.Interfaces.Repositories;
using Ex1_API.Core;

namespace Ex1_API.Database.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly Connection _connection;
        public AlunoRepository(Connection connection)
        {
            _connection = connection;
        }
        public void Adicionar(Aluno aluno)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "INSERT INTO Aluno (Nome, Cidade, Idade)" +
                                      $"VALUES ({aluno.Nome}, {aluno.Cidade}, {aluno.Idade})";
                
                command.ExecuteNonQuery();
            }
        }
    }
}
