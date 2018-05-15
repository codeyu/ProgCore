using EfCore.Backend.Persistence.Model;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Backend.Persistence
{
    public class SQLiteDbContext : DbContext
    {
        
        public SQLiteDbContext(DbContextOptions options) : base(options)
        { 
            Database.EnsureCreated();
        }
        public DbSet<Customer> Customers { get; set; }
    }
}