using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NUShop.Data.Entities;
using NUShop.Infrastructure.Interfaces;
using NUShop.Service.Interfaces;
using NUShop.Utilities.DTOs;
using NUShop.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NUShop.Service.Implements
{
    public class RoleService : IRoleService
    {
        #region Injections

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly RoleManager<AppRole> _roleManager;

        public RoleService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            RoleManager<AppRole> roleManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public List<AppRoleViewModel> GetAll()
        {
            var roles = _roleManager.Roles;
            var rolesViewModel = _mapper.Map<List<AppRoleViewModel>>(roles);
            return rolesViewModel;
        }

        public async Task<AppRoleViewModel> GetByIdAsync(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            var roleViewModel = _mapper.Map<AppRoleViewModel>(role);
            return roleViewModel;
        }

        public PagedResult<AppRoleViewModel> GetAllPaging(string keyword, int pageSize, int pageIndex = 1)
        {
            var roles = _roleManager.Roles;
            if (!string.IsNullOrEmpty(keyword))
            {
                roles = roles.Where(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            }

            var totalRow = roles.Count();
            roles = roles.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            var rolesViewModel = _mapper.Map<List<AppRoleViewModel>>(roles);
            var paginationSet = new PagedResult<AppRoleViewModel>()
            {
                Results = rolesViewModel,
                CurrentPage = pageIndex,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;
        }

        public async Task UpdateAsync(AppRoleViewModel appRoleViewModel)
        {
            var roles = await _roleManager.FindByIdAsync(appRoleViewModel.Id.ToString());
            roles.Name = appRoleViewModel.Name;
            roles.Description = appRoleViewModel.Description;
            await _roleManager.UpdateAsync(roles);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            await _roleManager.DeleteAsync(role);
            await _unitOfWork.CommitAsync();
        }

        public Task<bool> CheckPermission(string functionId, string action, string[] roles)
        {
            throw new NotImplementedException();
        }

        #endregion Injections
    }
}