using Models;

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
            string json = "[";

            foreach (var item in list)
                json += item.ToJson() + ",";

            json = json.Substring(0, json.Length - 1);
            json += "]";

            try
            {
                using var sw = new StreamWriter(_path + _fileName);
                sw.WriteLine(json);
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
