using PetShop.Petshop.Models;

namespace PetShop.Petshop.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UsersInfo> GetUserByIDAsync(int EmployeeID);
        Task<IEnumerable<UsersInfo>> GetAllUserAsync();
        Task<UsersInfo> AddUsertAsync(UsersInfo employee);
        Task<UsersInfo> UpdateUserAsync(UsersInfo employee);
        Task DeleteUsertAsync(int id);
    }
}
