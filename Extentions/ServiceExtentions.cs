using PetShop.Petshop.Repositories.Interfaces;
using PetShop.Petshop.Repositories.Repositories;
using PetShop.Petshop.services.Interfaces;
using PetShop.Petshop.services.Services;

namespace PetShop.Extentions
{
    public class ServiceExtentions
    {
        public static IServiceCollection RegisterRepositories(IServiceCollection services)
        {
            services.AddSingleton<IEmployeeReposity, EmployeeRepository>();
            services.AddSingleton<IPetRepository, PetRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IEmployeeService, EmployeeService>();
            services.AddSingleton<IPetService, PetService>();
            services.AddSingleton<IIdentityService, IdentityService>();

            return services;
        }
    }
}
