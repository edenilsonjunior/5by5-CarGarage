using Models;
using Repositories;

namespace Services
{
    public class CarOperationService
    {
        private CarOperationRepository _carOperationRepository;
        public CarOperationService()
        {
            _carOperationRepository = new();
        }

        public bool Insert(CarOperation co) => _carOperationRepository.Insert(co);
    }
}
