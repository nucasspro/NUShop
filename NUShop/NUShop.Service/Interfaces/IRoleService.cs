using NUShop.Utilities.DTOs;
using NUShop.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NUShop.Service.Interfaces
{
    public interface IRoleService
    {
        List<AppRoleViewModel> GetAll();
        Task<AppRoleViewModel> GetByIdAsync(Guid id);
        PagedResult<AppRoleViewModel> GetAllPaging(string keyword, int pageSize, int pageIndex = 1);
        Task UpdateAsync(AppRoleViewModel userVm);
        Task DeleteAsync(Guid id);

        //Task<bool> AddAsync(AnnouncementViewModel announcement, List<AnnouncementUserViewModel> announcementUsers, AppRoleViewModel userVm);
        //List<PermissionViewModel> GetListFunctionWithRole(Guid roleId);
        //void SavePermission(List<PermissionViewModel> permissions, Guid roleId);
        Task<bool> CheckPermission(string functionId, string action, string[] roles);
    }
}
