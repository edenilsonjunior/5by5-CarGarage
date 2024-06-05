using Models;
using Repositories;
namespace Services
{
    public class CarService
    {
        private CarRepository _carRepository;

        public CarService()
        {
            _carRepository = new();
        }

        public bool Insert(Car c)
        {
            var carList = _carRepository.GetAll();

            if (carList.Any(x => x.Plate == c.Plate))
                return false;

            return _carRepository.Insert(c);
        }

        public List<Car> GetAll() => _carRepository.GetAll();
    }
}
