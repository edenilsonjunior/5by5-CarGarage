using Models;
using Services;

namespace Controllers
{
    public class OperationController
    {
        private OperationService _operationService;
        public OperationController()
        {
            _operationService = new OperationService();
        }

        public bool Insert(Operation o) => _operationService.Insert(o);


        public List<Operation> GetAll() => _operationService.GetAll();
    }
}
