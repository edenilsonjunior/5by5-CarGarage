using Models;
using Repositories;
namespace Services
{
    public class ReportService
    {
        private ReportRepository _repository;

        public ReportService()
        {
            _repository = new ReportRepository();
        }

        public List<Car> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Car> GetByStatus()
        {
            var carList = GetAll();
            var carOperationList = _repository.GetAllCarOperation();

            if (carList == null)
                Console.WriteLine("Lista de carros nula");

            if (carOperationList == null)
                Console.WriteLine("Lista de operações nula");

            var filteredList = new List<Car>();




            foreach (var item in carList)
            {
                if (carOperationList.Any(x => x.Car.Plate.Equals(item.Plate) && x.Status == true))
                    filteredList.Add(item);
            }
            return filteredList;
        }

        public List<Car> GetByRedColor()
        {
            var carList = GetAll();
            var filteredList = new List<Car>();

            foreach (var item in carList)
            {
                if (item.Color.Equals("Vermelho"))
                    filteredList.Add(item);
            }
            return filteredList;
        }

        public List<Car> GetByYear()
        {
            var carList = GetAll();
            var filteredList = new List<Car>();

            foreach (var item in carList)
            {
                if (item.YearManufacture == 2010 || item.YearManufacture == 2011)
                    filteredList.Add(item);
            }
            return filteredList;
        }
    
        public void GenerateXml(List<Car> cars, string fileName) => _repository.GenerateXML(cars, fileName);

    }
}
