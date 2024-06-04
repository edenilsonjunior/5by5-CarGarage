using Models;
using Services;

namespace Controllers
{
    public class CarController
    {
        private CarService _carService;

        public CarController()
        {
            _carService = new CarService();
        }

        public bool InsertAll(List<Car> list)
        {
            return _carService.InsertAll(list);
        }
    }
}
