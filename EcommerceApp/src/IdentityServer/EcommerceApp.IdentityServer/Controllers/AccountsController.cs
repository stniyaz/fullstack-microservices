using EcommerceApp.IdentityServer.Dtos;
using EcommerceApp.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EcommerceApp.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountsController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterDto dto)
        {
            var newUser = new ApplicationUser
            {
                Name = dto.Name,
                Email = dto.Email,
                Surname = dto.Surname,
                UserName = dto.Username
            };

            var result = await _userManager.CreateAsync(newUser,dto.Password);

            if(!result.Succeeded)
            {
                return BadRequest("Something went wrong.");
            }
            else
            {
                return StatusCode(201,"User created successfully.");
            }
        }
    }
}
