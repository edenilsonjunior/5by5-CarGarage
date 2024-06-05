using Repositories;
using Models;

namespace Services
{
    public class CarService
    {
        private CarRepository _carRepository;

        public CarService()
        {
            _carRepository = new CarRepository();
        }

        public bool InsertAll(List<Car> cars)
        {
            try
            {
                bool result = _carRepository.InsertAll(cars);
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
                var list = _carRepository.GetAll();
                return list;
            }
            catch (DirectoryNotFoundException)
            {
                throw new InvalidOperationException("Falha ao recuperar os dados. Verifique o diretório de destino.");
            }
            catch (FileNotFoundException)
            {
                throw new InvalidOperationException("Falha ao recuperar os dados. Arquivo não encontrado");
            }
            catch (NullReferenceException)
            {
                throw new InvalidOperationException("Falha ao recuperar os dados. Lista vazia");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
