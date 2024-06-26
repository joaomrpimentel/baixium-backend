using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MinimalAPI.Models;

namespace MinimalAPI
{
    [Route("/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public UserController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        [HttpPost("")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var user = new User()
            {
                Name = model.Name,
                Email = model.Email,
                Description = model.Description,
                AvatarURL = model.avatarURL,
                UserName = model.Email,
                PasswordHash = model.Password,
            };
            var result = await userManager.CreateAsync(user, user.PasswordHash!);
            if (result.Succeeded)
                return Ok("Registration made successfully");

            return BadRequest("Error occured");
        }
    }
}