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

        public bool InsertAll(List<Car> cars)
        {
            try
            {
                bool result = _carService.InsertAll(cars);
                return result;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
        }

        public List<Car> GetAll()
        {
            try
            {
                var list = _carService.GetAll();
                return list;
            }
            catch (InvalidOperationException)
            {
                throw;
            }
        }
    }
}
