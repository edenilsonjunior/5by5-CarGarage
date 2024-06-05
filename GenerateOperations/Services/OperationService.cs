using Repositories;
using Models;
namespace Services
{
    public class OperationService
    {
        private OperationRepository _operationRepository;
        public OperationService() { _operationRepository = new OperationRepository(); }

        public bool Insert(Operation o) => _operationRepository.Insert(o);


        public List<Operation> GetAll() => _operationRepository.GetAll();

    }
}
