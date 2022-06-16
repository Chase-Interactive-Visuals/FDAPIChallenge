using FDAPIChallenge.Models;
using Microsoft.EntityFrameworkCore;
namespace FDAPIChallenge.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Aircraft>? Aircrafts { get; set; }
        public DbSet<AircraftTasks>? AircraftTasks { get; set; }
    }
}
