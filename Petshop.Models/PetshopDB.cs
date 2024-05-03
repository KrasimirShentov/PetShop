using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace PetShop.Petshop.Models
{
    public class PetshopDB : DbContext
    {
        private readonly IConfiguration _configuration;

        public PetshopDB(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { EmployeeID = 1, EmployeeName = "Test 1", EmployeeAge = 15, EmployeePhone = "0893595954", EmployeeSurname = "Test 1", JobTitle = "Pet caretaker",  },
                new Employee { EmployeeID = 2, EmployeeName = "Test 2", EmployeeAge = 115, EmployeePhone = "0893595953", EmployeeSurname = "Test 2", JobTitle = "Pet caretaker", }
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Petshop"));
        }

        public DbSet<Employee> employees { get; set; }
        public DbSet<Pet> pets { get; set; }
        public DbSet<UsersInfo> usersInfos { get; set; }
    }
}
