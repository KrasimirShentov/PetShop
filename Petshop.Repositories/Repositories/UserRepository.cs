using Microsoft.EntityFrameworkCore;
using PetShop.Petshop.Models;
using PetShop.Petshop.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShop.Petshop.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PetshopDB _dbContext;

        public UserRepository(PetshopDB dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserInfo> GetUserByIDAsync(int userID)
        {
            return await _dbContext.users.FindAsync(userID);
        }

        public async Task<UserInfo> AddUserAsync(UserInfo user)
        {
            _dbContext.users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
    }
}
