using Models;
using Newtonsoft.Json;
using System.Text.Json;

namespace Repositories
{
    public class CarRepository
    {
        private readonly string _path;
        private readonly string _fileName;

        public CarRepository()
        {
            _path = @"../../../../../Documents/";
            _fileName = "mock.json";

            CreateDirectory();
            CreateFile();
        }

        public bool InsertAll(List<Car> list)
        {
            try
            {
                File.WriteAllText(_path + _fileName, JsonConvert.SerializeObject(list));
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
                return false;
            }
            return true;
        }

        private void CreateDirectory()
        {
            if (!Directory.Exists(_path))
                Directory.CreateDirectory(_path);
        }

        private void CreateFile()
        {
            if (!File.Exists(_path + _fileName))
            {
                var f = File.Create(_path + _fileName);
                f.Close();
            }
        }
    }
}
