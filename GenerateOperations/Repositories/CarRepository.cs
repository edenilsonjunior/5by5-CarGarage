using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using System.Configuration;


namespace Repositories
{
    public class CarRepository
    {
        private string _conn;

        public CarRepository()
        {
            _conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
        }

        public bool Insert(Car c)
        {
            using var connection = new SqlConnection(_conn);
            connection.Open();
            return connection.Execute(Car.INSERT, c) > 0;
        }

        public List<Car> GetAll()
        {
            using var connection = new SqlConnection(_conn);
            connection.Open();
            return connection.Query<Car>(Car.SELECT).ToList();
        }
    }
}
