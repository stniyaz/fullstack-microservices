using EcommerceApp.IdentityServer.Dtos;
using EcommerceApp.IdentityServer.Models;
using EcommerceApp.IdentityServer.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace EcommerceApp.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountsController(UserManager<ApplicationUser> userManager,
                                  SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp(RegisterDto dto)
        {
            var newUser = new ApplicationUser
            {
                Name = dto.Name,
                Email = dto.Email,
                Surname = dto.Surname,
                UserName = dto.Username
            };

            var result = await _userManager.CreateAsync(newUser, dto.Password);

            if (!result.Succeeded)
            {
                return BadRequest("Something went wrong.");
            }
            else
            {
                return StatusCode(201, "User created successfully.");
            }
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn(LoginDto dto)
        {
            var result = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, dto.RememberMe, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(dto.Username);
                var model = new GetCheckAppUserViewModel();
                model.Username = dto.Username;
                model.Id = user.Id;

                var token = JwtTokenGenerator.GenereateToken(model);

                return Ok(token);
            }

            return BadRequest("Invalid username or password.");
        }

        [HttpGet("signout")]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();

            return Ok("Signout successfull.");
        }

        [HttpGet("getuserinfo")]
        public async Task<IActionResult> GetUserInfo()
        {
            var userClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);

            var user = await _userManager.FindByIdAsync(userClaim.Value);

            return Ok(new
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Surname = user.Surname,
                Username = user.UserName,
            });
        }
    }
}
