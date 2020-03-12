using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Museo.Security
{
    public class CanEditOtherUsersRolesHandler : AuthorizationHandler<ManageOtherUsersRolesRequirement>
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public CanEditOtherUsersRolesHandler(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            ManageOtherUsersRolesRequirement requirement)
        {
            string loggedInAdminId = context.User.Claims.FirstOrDefault(
                c => c.Type == ClaimTypes.NameIdentifier).Value;

            string adminIdBeingEdited = httpContextAccessor.HttpContext.Request.Path.Value.Split('/').Last();

            if (adminIdBeingEdited.ToLower() != loggedInAdminId.ToLower())
                context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
