using MySql.Data.MySqlClient;
using System.Data;

namespace ProjectHonor1.Models
{
    public class DapperContext
    {
        private readonly string _connectionString;
        public DapperContext(string connectionString)
        {
            _connectionString=connectionString;
        }
        public IDbConnection CreateConnection()
        {
            return new MySqlConnection(_connectionString);

        }
    }
}
