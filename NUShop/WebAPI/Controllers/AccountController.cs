using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUShop.Data.Entities;
using NUShop.Utilities.DTOs;
using NUShop.ViewModel.ViewModels.AccountViewModels;

namespace NUShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        #region Injections

        private readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(SignInManager<AppUser> signInManager, ILogger<AccountController> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        #endregion Injections

        #region API


        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> AuthenticationAsync(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return new OkObjectResult(new GenericResult(false, loginViewModel));
            }

            var result = await _signInManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, loginViewModel.RememberMe, true);
            if (result.Succeeded)
            {
                _logger.LogInformation("User logged in.");
                return new OkObjectResult(new GenericResult(true));
            }

            if (!result.IsLockedOut)
            {
                return new OkObjectResult(new GenericResult(false, "Wrong user or password."));
            }

            _logger.LogWarning("User account locked out.");
            return new OkObjectResult(new GenericResult(false, "User account locked out."));

        }


        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await _signInManager.SignOutAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException.Message);
            }
        }


        #endregion
    }
}