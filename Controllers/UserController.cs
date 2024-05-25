//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.IdentityModel.Tokens;
//using PetShop.Petshop.Models;
//using System.IdentityModel.Tokens.Jwt;
//using System.Security.Claims;
//using System.Text;

//// ...

//[Route("api/[controller]")]
//[ApiController]
//public class UserController : ControllerBase
//{
//    private readonly IConfiguration _configuration;

//    public UserController(IConfiguration configuration)
//    {
//        _configuration = configuration;
//    }

//    [HttpPost("login")]
//    public IActionResult Login(LoginModel model)
//    {
//        // Simulate user authentication (replace with actual authentication logic)
//        if (model.Username == "admin" && model.Password == "password")
//        {
//            var tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOption>();
//            var key = Encoding.ASCII.GetBytes(tokenOptions.Secret);

//            var tokenDescriptor = new SecurityTokenDescriptor
//            {
//                Subject = new ClaimsIdentity(new[]
//                {
//                    new Claim(ClaimTypes.Name, model.Username)
//                }),
//                Expires = DateTime.UtcNow.AddDays(tokenOptions.ExpiryDays),
//                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
//            };

//            var tokenHandler = new JwtSecurityTokenHandler();
//            var token = tokenHandler.CreateToken(tokenDescriptor);

//            return Ok(new { token = tokenHandler.WriteToken(token) });
//        }

//        return Unauthorized();
//    }
//}