using Microsoft.EntityFrameworkCore;
using NasaAPI.DataAccess.Entities;

namespace NasaAPI.DataAccess
{
    public class ApplicationContext : DbContext
    {
        DbSet<AsteroidNeoWS> Asteroids { get; set; } = null!;
        public ApplicationContext() { }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");
        }
    }
}
