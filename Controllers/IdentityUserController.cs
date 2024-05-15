//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.Data;
//using Microsoft.AspNetCore.Mvc;
//using PetShop.Petshop.Models;
//using PetShop.Petshop.Models.Petshop.Responses;
//using PetShop.Petshop.services.Interfaces;
//using PetShop.Petshop.Models.Petshop.Requests;

//namespace PetShop.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class IdentityUserController : ControllerBase
//    {
//        private readonly IIdentityService _identityService;

//        [HttpPost("/user")]
//        public async Task<IActionResult> CreateUser([FromQuery] UsersInfo usersInfo)
//        { 
//            try
//            {
//                var createUser = await _identityService.CreateAsync(usersInfo);

//                if (createUser.Succeeded)
//                {
//                    return Ok("User created successfully!");
//                }
//                else
//                {
//                    return BadRequest(createUser.Errors);
//                }
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Internal server error: {ex.Message}");
//            }
//        }

//        [HttpPost("/Login")]
//        public async Task<IActionResult> UserLogin(UserLoginRequest loginRequest)
//        {
//            try
//            {
//                var user = await _identityService.CheckUserAndPass(loginRequest.Password, loginRequest.UserName);

//                if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
//                {
//                    return BadRequest("Username or password is missing");
//                }
//                else
//                {
//                    return Ok("Login successful");
//                }
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, $"Internal server error: {ex.Message}");
//            }
//        }
//    }
//}
