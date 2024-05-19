using Microsoft.EntityFrameworkCore;

namespace PetShop.Petshop.Models
{
    public class PetshopDB : DbContext
    {
        private readonly IConfiguration _configuration;

        public PetshopDB(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Petshop"));
        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Pet> pets { get; set; }
    }
}
