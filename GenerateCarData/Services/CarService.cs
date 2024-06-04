using Models;
using Repositories;

namespace Services
{
    public class CarService
    {
        private CarRepository _carRepository;

        public CarService()
        {
            _carRepository = new CarRepository();
        }

        public bool InsertAll(List<Car> list)
        {
            return _carRepository.InsertAll(list);
        }
    }
}
