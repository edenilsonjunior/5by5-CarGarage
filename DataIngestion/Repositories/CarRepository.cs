using Dapper;
using Microsoft.Data.SqlClient;
using Models;
using Newtonsoft.Json;
using System.Configuration;


namespace Repositories
{
    public class CarRepository
    {
        private string _conn;
        private string _path;
        private string _fileName;

        public CarRepository()
        {
            _conn = ConfigurationManager.ConnectionStrings["StringConnection"].ConnectionString;
            _path = ConfigurationManager.AppSettings["Path"];
            _fileName = ConfigurationManager.AppSettings["FileName"];
        }

        public bool InsertAll(List<Car> cars)
        {
            using var connection = new SqlConnection(_conn);
            connection.Open();

            return connection.Execute(Car.INSERT, cars) > 0;
        }

        public List<Car> GetAll()
        {
            if (!Directory.Exists(_path))
                return null;

            if (!File.Exists(_path + _fileName))
                return null;


            using var sr = new StreamReader(_path + _fileName);
            string str = sr.ReadToEnd();
            var list = JsonConvert.DeserializeObject<List<Car>>(str);

            if (list == null)
                return null;

            return list;
        }
    }
}
