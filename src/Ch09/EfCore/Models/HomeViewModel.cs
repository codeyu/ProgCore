using System.Collections.Generic;
using EfCore.Backend.Persistence.Model;

namespace EfCore.Models
{
    public class HomeViewModel  
    {
        public IList<Customer> Records { get; set; }
    }
}