using PetShop.Petshop.Models;

namespace PetShop.Petshop.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UsersInfo> GetUserByIDAsync(int EmployeeID);
        Task<IEnumerable<UsersInfo>> GetAllUserAsync();
        Task AddUsertAsync(UsersInfo employee);
        Task UpdateUserAsync(UsersInfo employee);
        Task DeleteUsertAsync(int id);
    }
}
