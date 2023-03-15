using System.Data.SqlClient;

namespace Ex1_API.Database
{
    public class Connection : IDisposable
    {
        private readonly SqlConnection _connection;

        public Connection(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }

        public SqlCommand CreateCommand()
        {
            return _connection.CreateCommand();
        }

        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
        }
    }
}