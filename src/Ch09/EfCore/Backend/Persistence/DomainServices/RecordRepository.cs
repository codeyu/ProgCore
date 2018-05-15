using System.Collections.Generic;
using System.Linq;
using EfCore.Backend.Persistence.Model;

namespace EfCore.Backend.Persistence.DomainServices
{
    public class RecordRepository  
    {
        private readonly SQLiteDbContext _dbContext;
        public RecordRepository(SQLiteDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IList<Customer> GetRecords()
        {
            
                var list = (from c in _dbContext.Customers select c).ToList();
                return list;
            
        }

        public void Save(Customer customer)
        {
            
                var existing = (from c in _dbContext.Customers
                    where c.Id == customer.Id
                    select c).SingleOrDefault();
                if (existing == null)
                {
                    _dbContext.Customers.Add(customer);
                }
                else
                {
                    existing.FirstName = customer.FirstName;
                    existing.LastName = customer.LastName;
                }
                _dbContext.SaveChanges();
            
        }
    }
}