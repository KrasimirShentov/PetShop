using PetShop.Petshop.Models;
using PetShop.Petshop.Models.Petshop.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShop.Petshop.services.Interfaces
{
    public interface IUserService
    {
        Task<UserInfo> GetUserByIDAsync(int userID);
        Task<UserInfo> AddUserAsync(UserRequest userRequest);
        string HashPassword(string password);
    }
}
