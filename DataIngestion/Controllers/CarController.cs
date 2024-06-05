using Services;
using Models;

namespace Controllers
{
    public class CarController
    {
        private CarService _carService;

        public CarController()
        {
            _carService = new CarService();
        }

        public bool InsertAll(List<Car> cars) => _carService.InsertAll(cars);

        public List<Car> GetAll() => _carService.GetAll();
    }
}
