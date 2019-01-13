﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUShop.Service.Interfaces;
using NUShop.ViewModel.ViewModels;
using NUShop.WebMVC.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NUShop.WebMVC.Areas.Admin.Controllers
{
    public class RoleController : BaseController
    {
        #region Injections

        private readonly IRoleService _roleService;
        private readonly ILogger<RoleController> _logger;

        public RoleController(IRoleService roleService, ILogger<RoleController> logger)
        {
            _roleService = roleService;
            _logger = logger;
        }

        #endregion Injections

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var roles = _roleService.GetAll();
                return new OkObjectResult(roles);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.InnerException.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                var role = await _roleService.GetByIdAsync(id);
                return new OkObjectResult(role);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.InnerException.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllPaging(string keyword, int pageSize, int pageIndex = 1)
        {
            try
            {
                var page = _roleService.GetAllPaging(keyword, pageSize, pageIndex);
                return new OkObjectResult(page);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.InnerException.Message);
            }
        }

        [HttpPost]
        public IActionResult GetAllFunction(Guid roleId)
        {
            var functions = _roleService.GetAllFunction(roleId);
            return new OkObjectResult(functions);
        }

        [HttpPut]
        public async Task<IActionResult> Update(AppRoleViewModel appRoleViewModel)
        {
            if (!ModelState.IsValid)
            {
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            try
            {
                await _roleService.UpdateAsync(appRoleViewModel);
                return new OkObjectResult(appRoleViewModel);
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.InnerException.Message);
            }
        }

        [HttpPost]
        public IActionResult UpdatePermission(List<PermissionViewModel> listPermmission, Guid roleId)
        {
            _roleService.UpdatePermission(listPermmission, roleId);
            return new OkResult();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AppRoleViewModel appRoleViewModel)
        {
            if (!ModelState.IsValid)
            {
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            if (!appRoleViewModel.Id.HasValue)
            {
                var notificationId = Guid.NewGuid().ToString();
                var announcement = new AnnouncementViewModel()
                {
                    Title = "Role created",
                    DateCreated = DateTime.Now,
                    Content = $"Role {appRoleViewModel.Name} has been created",
                    Id = notificationId,
                    UserId = User.GetUserId()
                };
                var announcementUsers = new List<AnnouncementUserViewModel>()
                {
                    new AnnouncementUserViewModel(){AnnouncementId = notificationId,HasRead = false,UserId = User.GetUserId()}
                };
                await _roleService.AddAsync(announcement, announcementUsers, appRoleViewModel);
            }
            return new OkObjectResult(appRoleViewModel);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid roleId)
        {
            if (!ModelState.IsValid)
            {
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }
            try
            {
                await _roleService.DeleteAsync(roleId);
                return Ok();
            }
            catch (Exception e)
            {
                return new BadRequestObjectResult(e.InnerException.Message);
            }

        }
    }
}