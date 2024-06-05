using Models;
using Services;

namespace Controllers
{
    public class CarController
    {
        private CarService _carService;

        public CarController() { _carService = new(); }

        public bool Insert(Car c) => _carService.Insert(c);

        public List<Car> GetAll() => _carService.GetAll();

    }
}
