using Microsoft.AspNetCore.Mvc;
using NUShop.Service.Interfaces;
using NUShop.ViewModel.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace NUShop.WebMVC.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        #region Injections

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion Injections

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return new OkObjectResult(users);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(string id)
        {
            var user = await _userService.GetById(id);
            return new OkObjectResult(user);
        }

        [HttpGet]
        public IActionResult GetAllPaging(string keyword, int pageSize, int pageIndex = 1)
        {
            var pageResult = _userService.GetAllPaging(keyword, pageSize, pageIndex);
            return new OkObjectResult(pageResult);
        }

        [HttpPut]
        public async Task<IActionResult> Update(AppUserViewModel appuserviewmodel)
        {
            if (!ModelState.IsValid)
            {
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            await _userService.UpdateAsync(appuserviewmodel);
            return new OkObjectResult(appuserviewmodel);
        }

        [HttpPut]
        public async Task<IActionResult> Add(AppUserViewModel appuserviewmodel)
        {
            if (!ModelState.IsValid)
            {
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            await _userService.AddAsync(appuserviewmodel);
            return new OkObjectResult(appuserviewmodel);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            await _userService.DeleteAsync(id);
            return new OkObjectResult(id);
        }
    }
}