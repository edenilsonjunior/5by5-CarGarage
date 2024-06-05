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
            if (cars.Count == 0)
                throw new InvalidOperationException("Lista vazia");


            using var connection = new SqlConnection(_conn);
            try
            {
                connection.Open();
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Falha ao conectar com o banco de dados");
            }

            var query = "INSERT INTO Car (Plate, Name, YearManufacture, YearModel, Color) ";
            query += "VALUES (@Plate, @Name, @YearManufacture, @YearModel, @Color)";

            int result;
            try
            {
                 result = connection.Execute(query, cars);
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Falha ao inserir os dados");
            }

            return result > 0;
        }

        public List<Car> GetAll()
        {
            if (!Directory.Exists(_path))
                throw new DirectoryNotFoundException("Diretório não encontrado");

            if (!File.Exists(_path + _fileName))
                throw new FileNotFoundException("Arquivo não encontrado");


            using var sr = new StreamReader(_path + _fileName);
            string str = sr.ReadToEnd();
            var list = JsonConvert.DeserializeObject<List<Car>>(str);

            if (list == null)
                throw new NullReferenceException("Lista vazia");

            return list;
        }
    }
}
