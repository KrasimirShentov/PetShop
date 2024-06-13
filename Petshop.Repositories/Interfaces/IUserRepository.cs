using PetShop.Petshop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShop.Petshop.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserInfo> GetUserByIDAsync(int userID);
        Task<UserInfo> AddUserAsync(UserInfo user);
    }
}
