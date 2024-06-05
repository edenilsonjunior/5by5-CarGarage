using Microsoft.Data.SqlClient;
using Models;
using System.Configuration;
using Dapper;

namespace Repositories
{
    public class CarOperationRepository
    {

        private string _conn;

        public CarOperationRepository()
        {
            _conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;

        }

        public bool Insert(CarOperation co)
        {
            using var connection = new SqlConnection(_conn);
            connection.Open();

            object obj = new {CarPlate = co.Car.Plate, OperationId = co.Operation.Id, Status = co.Status };
            return connection.Execute(CarOperation.INSERT, obj) > 0;
        }
    }
}
