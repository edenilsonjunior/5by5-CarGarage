using Models;
using Services;

namespace Controllers
{
    public class ReportController
    {
        private ReportService _service;

        public ReportController()
        {
            _service = new ReportService();
        }

        public List<Car> GetAll() => _service.GetAll();

        public List<Car> GetByStatus() => _service.GetByStatus();

        public List<Car> GetByRedColor() => _service.GetByRedColor();

        public List<Car> GetByYear() => _service.GetByYear();

    }
}
