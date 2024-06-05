using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System.Configuration;

namespace Repositories
{
    public class OperationRepository
    {
        private string _conn;

        public OperationRepository()
        {
            _conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }

        public bool Insert(Operation o)
        {
            using var connection = new SqlConnection(_conn);
            connection.Open();
            return connection.Execute(Operation.INSERT, o) > 0;
        }

        public List<Operation> GetAll()
        {
            using var connection = new SqlConnection(_conn);
            connection.Open();
            return connection.Query<Operation>(Operation.SELECT).ToList();
        }
    }
}
