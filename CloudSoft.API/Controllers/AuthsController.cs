using CloudSoft.Data.Entities.Auth;
using CloudSoft.Data.Entities.DTOs;
using CloudSoft.Service.Abstractions.AuthServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace CloudSoft.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAuthService _authService;
        private readonly ILogger<AuthsController> _logger;
        private readonly IConfiguration _configuration;

        public AuthsController(UserManager<IdentityUser> userManager, 
                               SignInManager<IdentityUser> signInManager, 
                               RoleManager<IdentityRole> roleManager,
                               IAuthService authService,
                               ILogger<AuthsController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _authService = authService;
            _logger = logger;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> Register(RegisterDTO registerUser)
        {


            var userExists = await _userManager.FindByEmailAsync(registerUser.Email);

            

            if (userExists != null)
            {
                _logger.LogInformation("Bu email bor");
                return StatusCode(StatusCodes.Status403Forbidden,
                    new ResponseModel { IsSuccess = true, Message = "User already exists" }
                    );
            }

            

          

            IdentityUser user = new()
            {
                Email = registerUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUser.UserName,
            };

            if (await _roleManager.RoleExistsAsync("User"))
            {
                var result = await _userManager.CreateAsync(user, registerUser.Password);



                if (!result.Succeeded)
                {

                    return StatusCode(StatusCodes.Status500InternalServerError,
                     new ResponseModel { IsSuccess = false, Message = "User Failed to create" }
                    );

                }
                await _userManager.AddToRoleAsync(user, "User");




                // Add token to verify the email


             /*   var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var confirmationLink = Url.Action(nameof(ConfirmEmail), "Authentication", new { token, email = user.Email }, Request.Scheme);
                var message = new Message(new string[] { user.Email! }, "Confirmation email link", confirmationLink!);
                _emailService.SendEmail(message);*/





                return StatusCode(StatusCodes.Status200OK,
                    new ResponseModel { IsSuccess = true, Message = $"User created  & Email Sent to {user.Email} Successfully " }
                    );


            }
            else
            {


                return StatusCode(StatusCodes.Status500InternalServerError,
                    new ResponseModel { IsSuccess = false, Message = "This role doesnt exists" });

            }






        }






        [HttpPost("SignIn")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(loginModel.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                return Unauthorized();
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var role = userRoles.FirstOrDefault() ?? "User"; // Agar foydalanuvchida bir nechta rol bo'lsa, birinchisini oladi yoki "User" deb belgilaydi

            var result = new UserApp
            {
             
                Name = user.UserName,
                Email = user.Email,
                Role = role
            };

            var token = await _authService.GenerateToken(result);
            return Ok(new { Token = token });
        }






    }




















}
