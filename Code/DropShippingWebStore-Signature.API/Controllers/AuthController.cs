using DropShippingWebStore_Signature.DTOs.UserDtos;
using DropShippingWebStore_Signature.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DropShippingWebStore_Signature.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IAuthenticationService _authService;

        public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IAuthenticationService authService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            var user = new IdentityUser { UserName = model.Username, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (!result.Succeeded)
                return Unauthorized("Invalid login attempt");

            var user = await _userManager.FindByNameAsync(model.Username); //change if neceserry to search by username
            var token = await _authService.GenerateTokenAsync(user);

            return Ok(new { Token = token });
        }
    }
}
