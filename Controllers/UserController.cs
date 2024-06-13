using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PetShop.Petshop.Models;
using PetShop.Petshop.services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IUserService _userService;
    private readonly TokenOptions _tokenOptions;

    public UserController(IConfiguration configuration, IUserService userService, IOptions<TokenOptions> tokenOptions)
    {
        _configuration = configuration;
        _userService = userService;
        _tokenOptions = tokenOptions.Value;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRequest model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (model == null)
        {
            return BadRequest("UserRequest model is null.");
        }

        if (string.IsNullOrWhiteSpace(model.Password))
        {
            return BadRequest("Password is required.");
        }

        var newUser = new UserRequest
        {
            UserID = model.UserID,
            Username = model.Username,
            Password = model.Password,
            Email = model.Email,
            CreateOn = DateTime.UtcNow
        };

        UserInfo user;

        try
        {
            user = await _userService.AddUserAsync(newUser);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }

        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserRequest model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await _userService.GetUserByIDAsync(model.UserID);
        if (user == null)
        {
            return Unauthorized("Invalid username or password.");
        }

        if (user.Password != model.Password)
        {
            return Unauthorized("Invalid username or password.");
        }

        var keyBytes = Encoding.ASCII.GetBytes(_tokenOptions.Secret);

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.Name, user.Username)
        }),
            NotBefore = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddDays(_tokenOptions.ExpiryDays),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return Ok(new { token = tokenHandler.WriteToken(token) });
    }
}
