using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUShop.Data.Entities;

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

        [HttpPost]
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