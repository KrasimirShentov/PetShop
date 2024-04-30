using PetShop.Petshop.Models;
using PetShop.Petshop.Repositories.Interfaces;

namespace PetShop.Petshop.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<UsersInfo> _users;
        private int _userID = 0;
        public async Task<IEnumerable<UsersInfo>> GetAllUserAsync()
        {
            return await Task.FromResult(_users);
        }

        public async Task<UsersInfo> GetUserByIDAsync(int userID)
        {
            return await Task.FromResult(_users.FirstOrDefault(x => x.UserID == userID));
        }
        public async Task<UsersInfo> AddUsertAsync(UsersInfo user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
                user.UserID = _userID++;
                _users.Add(user);
                return user;
            }
        }

        public async Task DeleteUsertAsync(int userID)
        {
            var userToDelete = await GetUserByIDAsync(userID);
            if (userToDelete != null)
            {
                _users.Remove(userToDelete);
                await Task.CompletedTask;
            }
            else
            {
                throw new ArgumentNullException($"User with this ID {userID} does not exist");
            }
        }


        public async Task<UsersInfo> UpdateUserAsync(UsersInfo user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
                var existingUser = await GetUserByIDAsync(user.UserID);
                existingUser.UserID = user.UserID;
                existingUser.UserName = user.UserName;
                existingUser.Password = user.Password;
                existingUser.Email = user.Email;
                return user;
            }
        }
    }
}
