//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Identity;
//using PetShop.Petshop.Models;
//using PetShop.Petshop.services.Interfaces;

//namespace PetShop.Petshop.services.Services
//{
//    public class IdentityService : IIdentityService
//    {
//        private readonly UserManager<UsersInfo> _userManager;

//        public IdentityService(UserManager<UsersInfo> userManager)
//        {
//            _userManager = userManager;
//        }

//        public async Task<UsersInfo?> CheckUserAndPass(string userName, string password)
//        {
//            var user = await _userManager.FindByNameAsync(userName);
//            if (user != null && await _userManager.CheckPasswordAsync(user, password))
//            {
//                return user;
//            }
//            else
//            {
//                return null;
//            }
//        }

//        public async Task<IdentityResult> CreateAsync(UsersInfo user)
//        {
//            var newUser = await _userManager.GetUserIdAsync(user);

//            if (string.IsNullOrEmpty(newUser))
//            {
//                return await _userManager.CreateAsync(user);
//            }
//            return IdentityResult.Failed();
//        }

//        public async Task<IEnumerable<string>> GetUserRoles(UsersInfo user)
//        {
//            return await _userManager.GetRolesAsync(user);
//        }
//    }
//}
