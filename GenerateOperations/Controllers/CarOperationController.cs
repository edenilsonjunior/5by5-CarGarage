using Models;
using Services;

namespace Controllers
{
    public class CarOperationController
    {
        public CarOperationService _carOperationService;

        public CarOperationController() { _carOperationService = new CarOperationService(); }

        public bool Insert(CarOperation co) => _carOperationService.Insert(co);
    }
}
