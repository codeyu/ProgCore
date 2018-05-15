using EfCore.Backend.Persistence.DomainServices;
using EfCore.Models;

namespace EfCore.Application
{
    public class HomeService
    {
        private readonly RecordRepository _repo;

        public HomeService(RecordRepository repo)
        {
            _repo = repo;
        }

        public HomeViewModel GetHomeViewModel()
        {
            var model = new HomeViewModel {Records = _repo.GetRecords()};
            return model;
        }
    }
}