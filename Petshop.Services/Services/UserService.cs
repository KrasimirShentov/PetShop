using PetShop.Petshop.Models;
using PetShop.Petshop.Repositories.Interfaces;
using PetShop.Petshop.services.Interfaces;
using System.Security.Cryptography;
using System.Text;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly PetshopDB _dbContext;

    public UserService(IUserRepository userRepository, PetshopDB dbContext)
    {
        _userRepository = userRepository;
        _dbContext = dbContext;
    }
    public async Task<UserInfo> GetUserByIDAsync(int userID)
    {
        var result = await _userRepository.GetUserByIDAsync(userID);
        if (result == null)
        {
            throw new ArgumentNullException(nameof(result));
        }
        return result;
    }

    public async Task<UserInfo> AddUserAsync(UserRequest userRequest)
    {
        var existingUser = await _userRepository.GetUserByIDAsync(userRequest.UserID);
        if (existingUser != null)
        {
            throw new InvalidOperationException($"User with ID: {existingUser.UserID} already exists");
        }

        if (userRequest.UserID <= 0)
        {
            throw new ArgumentException($"User ID must be greater than 0");
        }

        var newUser = new UserInfo
        {
            UserID = userRequest.UserID,
            Username = userRequest.Username,
            Password = userRequest.Password,
            PasswordHash = HashPassword(userRequest.Password),
            Email = userRequest.Email,
        };

        _dbContext.users.Add(newUser);
        await _dbContext.SaveChangesAsync();

        return newUser;
    }
    public string HashPassword(string password)
    {
        using (var hmac = new HMACSHA256())
        {
            var hashedPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedPassword);
        }
    }
}
