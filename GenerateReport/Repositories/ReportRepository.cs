using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System.Configuration;

namespace Repositories
{
    public class ReportRepository
    {
        private string _conn;

        public ReportRepository()
        {
            _conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }

        public List<Car> GetAll()
        {
            using var connection = new SqlConnection(_conn);
            connection.Open();
            return connection.Query<Car>(Car.SELECT).ToList();
        }

        public List<Operation> GetAllOperations()
        {
            using var connection = new SqlConnection(_conn);
            connection.Open();
            return connection.Query<Operation>(Operation.SELECT).ToList();
        }


        public List<CarOperation> GetAllCarOperation()
        {
            using var connection = new SqlConnection(_conn);
            connection.Open();

            var carList = GetAll();
            var operationList = GetAllOperations();
            var list = new List<CarOperation>();

            foreach (var row in connection.Query(CarOperation.SELECT))
            {
                string carPlate = row.CarPlate;
                string operation = row.Operation;
                bool status = row.Status;

                Car c = carList.Find(x => x.Plate.Equals(carPlate));
                Operation o = operationList.Find(x => x.Id.Equals(operation));

                CarOperation carOperation = new()
                {
                    Car = c,
                    Operation = o,
                    Status = status
                };

                list.Add(carOperation);
            }

            return list;
        }
    }
}
