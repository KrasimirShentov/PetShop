using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PetShop.Petshop.Models;
using PetShop.Petshop.services.Interfaces;

namespace PetShop.Petshop.services.Services
{
    public class UserService : IUserInfoService
    {
        private readonly UserManager<UsersInfo> _userManager;

        public UserService(UserManager<UsersInfo> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UsersInfo?> CheckUserAndPass(string userName, string password)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(userName);
                if (user != null && await _userManager.CheckPasswordAsync(user, password))
                {
                    return user;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking user credentials: {ex.Message}");
                throw;
            }
        }

        public async Task<IdentityResult> CreateAsync(UsersInfo user)
        {
            try
            {
                return await _userManager.CreateAsync(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating user: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<string>> GetUserRoles(UsersInfo user)
        {
            try
            {
                return await _userManager.GetRolesAsync(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting user roles: {ex.Message}");
                throw; 
            }
        }
    }
}
