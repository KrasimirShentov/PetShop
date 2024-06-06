using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PetShop.Petshop.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PetShop.Petshop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        //private readonly UserManager<IdentityUser> _userManager;
        //private readonly SignInManager<IdentityUser> _signInManager;

        public UserController(IConfiguration configuration/*, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager*/)
        {
            _configuration = configuration;
            //_userManager = userManager;
            //_signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var user = await _userManager.FindByEmailAsync(model.Email);
            //if (user != null && !(await _userManager.HasPasswordAsync(user)))
            //{
            //    // retrieve plaintext password
            //    var originalPassword = GetPlainTextPassword(user);

            //    var result = await _userManager.AddPasswordAsync(user, originalPassword);

            //    if (!result.Succeeded)
            //    {
            //        // handle error
            //    }
            //}


            //var user = await _userManager.FindByNameAsync(model.Username);
            //if (user == null)
            //{
            //    return Unauthorized();
            //}

            var tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOption>();
            var key = Encoding.ASCII.GetBytes(tokenOptions.Secret);
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, model.Username)
                }),
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddDays(tokenOptions.ExpiryDays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new { token = tokenHandler.WriteToken(token) });
        }
    }
}
