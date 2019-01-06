using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUShop.Data.Entities;
using NUShop.Service.ViewModels.AccountViewModels;
using NUShop.Utilities.DTOs;
using System.Threading.Tasks;

namespace NUShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        #region Injections

        private readonly UserManager<AppUser> _userManage;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<LoginController> _logger;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ILogger<LoginController> logger)
        {
            _userManage = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        #endregion Injections

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AuthenticationAsync(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, loginViewModel.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return new OkObjectResult(new GenericResult(true));
                }

                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return new OkObjectResult(new GenericResult(false, "User account locked out."));
                }
                else
                {
                    return new OkObjectResult(new GenericResult(false, "Wrong user or password."));
                }
            }

            // If we got this far, something failed, redisplay form
            return new OkObjectResult(new GenericResult(false, loginViewModel));
        }
    }
}