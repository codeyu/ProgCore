using System.Collections.Generic;
using EfCore.Backend.Persistence.Model;

namespace EfCore.Models
{
    public class RecordViewModel  
    {
        public RecordViewModel()
        {
            Customer = new Customer();
        }

        public Customer Customer { get; set; }
    }
}