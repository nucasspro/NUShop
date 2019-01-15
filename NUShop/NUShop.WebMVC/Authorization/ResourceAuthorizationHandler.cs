using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using NUShop.Service.Interfaces;
using NUShop.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NUShop.WebMVC.Authorization
{
    public class ResourceAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, string>
    {
        #region Injections
        private readonly IRoleService _roleService;

        public ResourceAuthorizationHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }
        #endregion


        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, string resource)
        {
            var roles = ((ClaimsIdentity)context.User.Identity).Claims.FirstOrDefault(x => x.Type == CommonConstants.UserClaims.Roles);

            if (roles == null)
            {
                context.Fail();
            }
            else
            {
                var listRole = roles.Value.Split(";");
                var hasPermission = await _roleService.CheckPermission(resource, requirement.Name, listRole);
                if (hasPermission || listRole.Contains(CommonConstants.AppRole.AdminRole))
                {
                    context.Succeed(requirement);
                }
                else
                {
                    context.Fail();
                }
            }

        }
    }
}
