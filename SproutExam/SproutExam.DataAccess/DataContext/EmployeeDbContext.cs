using Microsoft.EntityFrameworkCore;
using SproutExam.DataAccess.Entities;

namespace SproutExam.DataAccess.DataContext
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employee { get; set; }
    }
}
