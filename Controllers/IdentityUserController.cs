using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using PetShop.Petshop.Models;
using PetShop.Petshop.Models.Petshop.Responses;
using PetShop.Petshop.services.Interfaces;
using PetShop.Petshop.Models.Petshop.Requests;

namespace PetShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityUserController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        private readonly UserManager<UsersInfo> _userManager;

        public async Task<IActionResult> CreateUser(UsersInfo usersInfo)
        {
            try
            {
                var createUser = await _identityService.CreateAsync(usersInfo);

                if (createUser.Succeeded)
                {
                    return Ok("User created successfully!");
                }
                else
                {
                    return BadRequest(createUser.Errors);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        public async Task<IActionResult> UserLogin(UserLoginRequest loginRequest)
        {
            try
            {
                var user = await _identityService.CheckUserAndPass(loginRequest.Password, loginRequest.UserName);

                if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
                {
                    return BadRequest("Username or password is missing");
                }
                else
                {
                    return Ok("Login successful");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        public async Task<IActionResult> UpdateUser(int userID, UsersInfo usersInfo)
        {
            try
            {
                if (userID != usersInfo.UserID)
                {
                    return BadRequest($"User with this ID {userID} cannot be found!");
                }

                var result = await _userManager.UpdateAsync(usersInfo);

                if (result.Succeeded)
                {
                    return Ok("User's credentials has been updated successfully");
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        public async Task<IActionResult> DeleteUser(string UserID)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(UserID);

                if (user == null)
                {
                    return BadRequest($"User with ID {UserID} not found!");
                }

                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return Ok("User has been deleted successfully");
                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
