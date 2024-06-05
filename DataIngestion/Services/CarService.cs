using Repositories;
using Models;

namespace Services
{
    public class CarService
    {
        private CarRepository _carRepository;

        public CarService() { _carRepository = new CarRepository(); }

        public bool InsertAll(List<Car> cars) => _carRepository.InsertAll(cars);

        public List<Car> GetAll() => _carRepository.GetAll();

    }
}
