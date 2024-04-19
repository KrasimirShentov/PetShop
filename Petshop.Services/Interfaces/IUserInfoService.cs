using Microsoft.AspNetCore.Identity;
using PetShop.Petshop.Models;

namespace PetShop.Petshop.services.Interfaces
{
    public interface IUserInfoService
    {
        Task<IdentityResult> CreateAsync(UsersInfo user);
        Task<UsersInfo?> CheckUserAndPass(string userName, string password);
        public Task<IEnumerable<string>> GetUserRoles(UsersInfo user);
    }
}
