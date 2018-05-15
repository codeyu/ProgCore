//////////////////////////////////////////////////////////////////
//
//   PROGRAMMING ASP.NET CORE
//   Dino Esposito
//   
//   Ch09 - Access to Application Data
//   EfCore
// 

using EfCore.Backend.Persistence.DomainServices;
using EfCore.Backend.Persistence.Model;
using EfCore.Models;

namespace EfCore.Application
{
    public class RecordService
    {
        private readonly RecordRepository _repo;

        public RecordService(RecordRepository repo)
        {
            _repo = repo;
        }

        public RecordViewModel GetNewRecordViewModel()
        {
            var model = new RecordViewModel
            {
                Customer = {FirstName = "Dino"}
            };
            return model;
        }

        public void SaveRecord(string fn, string ln)
        {
            var customer = new Customer();
            customer.FirstName = fn;
            customer.LastName = ln;
            _repo.Save(customer);
        }
    }
}
