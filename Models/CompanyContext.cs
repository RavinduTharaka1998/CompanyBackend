using Microsoft.EntityFrameworkCore;
namespace CompanyBackend.Models
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Department { get; set; }
    }
}
