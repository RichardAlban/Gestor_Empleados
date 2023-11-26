using Microsoft.EntityFrameworkCore;
using Tarea6.Models.Domain;

namespace Tarea6.Data
{
    public class RazorPagesDemoDbContext : DbContext
    {
        public RazorPagesDemoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

    }
}
