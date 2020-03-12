using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Museo.Models.Security
{
    public class CanManageClaimHandler : AuthorizationHandler<ManageEntriesRequirement>
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public CanManageClaimHandler(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        protected async override Task HandleRequirementAsync(AuthorizationHandlerContext context, ManageEntriesRequirement requirement)
        {
            string loggedUserId = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

            var user = await userManager.FindByIdAsync(loggedUserId);

            if(user != null)
            {
                var rolenames = await userManager.GetRolesAsync(user);
                var roles = roleManager.Roles.Where(x => rolenames.Any(y => y == x.Name));
                foreach(var role in roles)
                {                    
                    var claims = await roleManager.GetClaimsAsync(role);
                    if (claims.Any(x => x.Value == requirement.requirement))
                        context.Succeed(requirement);
                }
            }
        }
    }
}
