using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Museo.Models;
using Museo.Models.Repository.Interfaces;
using Museo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Museo.Controllers
{
    //[AllowAnonymous]
    [Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<User> userManager;
        private readonly IAreaRepository areaRepository;
        private readonly IPositionRepository positionRepository;

        public AdministrationController(RoleManager<IdentityRole> roleManager, 
            UserManager<User> userManager, IAreaRepository areaRepository, IPositionRepository positionRepository)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.areaRepository = areaRepository;
            this.positionRepository = positionRepository;
        }

        [HttpGet]
        [Authorize(Policy = "ManageRolePolicy")]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Policy = "ManageRolePolicy")]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if(ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };
                IdentityResult result = await roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                    return RedirectToAction("ListRoles", "Administration");

                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

        [Authorize(Policy = "ManageRolePolicy")]
        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }

        [Authorize(Policy = "ManageRolePolicy")]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if(role == null)
            {
                ViewBag.ErrorMessage = $"Rol {id} no ha podido encontrarse";
                return View("ErrorPage");
            }

            var model = new EditRoleViewModel
            {
                Id = role.Id,
                RoleName = role.Name,
            };

            foreach(var user in userManager.Users)
            {
                if(await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }

            return View(model);
        }

        [HttpPost]
        [Authorize(Policy = "ManageRolePolicy")]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Rol {model.Id} no ha podido encontrarse";
                return View("ErrorPage");
            }

            role.Name = model.RoleName;
            var result = await roleManager.UpdateAsync(role);

            if (result.Succeeded)
                return RedirectToAction("ListRoles");

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);
            return View(model);         
        }

        [Authorize(Policy = "ManageRolePolicy")]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewBag.roleId = roleId;

            var role = await roleManager.FindByIdAsync(roleId);

            if(role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("ErrorPage");
            }

            var model = new List<UserRoleViewModel>();

            foreach(var user in userManager.Users)
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName
                };
                if (await userManager.IsInRoleAsync(user, role.Name))
                    userRoleViewModel.IsSelected = true;
                else
                    userRoleViewModel.IsSelected = false;

                model.Add(userRoleViewModel);
            }

            return View(model);
        }

        [HttpPost]
        [Authorize(Policy = "ManageRolePolicy")]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("ErrorPage");
            } 

            for(int i=0; i<model.Count; i++)
            {
                User user = await userManager.FindByIdAsync(model[i].UserId);

                IdentityResult result;
                if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                    result = await userManager.AddToRoleAsync(user, role.Name);
                else if (!model[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                else
                    continue;

                if(result.Succeeded && i == model.Count - 1)               
                        return RedirectToAction("EditRole", new { Id = roleId });                 
            }

            return RedirectToAction("EditRole", new { Id = roleId });
        }

        public IActionResult ListUsers()
        {
            List<AllUsersViewModel> viewModels = new List<AllUsersViewModel>();
            foreach (var item in userManager.Users)
            {
                AllUsersViewModel model = new AllUsersViewModel()
                {
                    Id = item.Id,
                    Area = areaRepository.GetById(item.AreaId).Name,
                    Position = positionRepository.GetById(item.PositionId).Name,
                    UserName = item.UserName,
                    FullName = item.FullName,
                    Email = item.Email,
                    Active = item.Active
                };
                viewModels.Add(model);
            }
            return View(viewModels);
        }

        [Authorize(Policy = "EditUserPolicy")]
        public async Task<IActionResult> EditUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if(user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("ErrorPage");
            }

            var roles = await userManager.GetRolesAsync(user);

            var model = new EditUserViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                FullName = user.FullName,
                Email = user.Email,
                Photo = user.Photo,
                Roles = roles.ToList()
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Policy = "DeleteUserPolicy")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("ErrorPage");
            }

            var result = await userManager.DeleteAsync(user);

            if (result.Succeeded)
                return RedirectToAction("ListUsers");

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return RedirectToAction("ListUsers");
        }

        [HttpPost]
        [Authorize(Policy = "ManageRolePolicy")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return View("ErrorPage");
            }

            var result = await roleManager.DeleteAsync(role);

            if (result.Succeeded)
                return RedirectToAction("ListRoles");

            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);

            return RedirectToAction("ListRoles");
        }

        [Authorize(Policy = "ManageRolePolicy")]
        [Authorize(Policy = "ManageOtherUsersRolesPolicy")]
        public async Task<IActionResult> ManageUserRoles(string id)
        {
            ViewBag.UserId = id;

            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("ErrorPage");
            }

            var model = new List<UserRolesViewModel>();

            foreach(var role in roleManager.Roles)
            {
                var userRoleViewModel = new UserRolesViewModel
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };

                if (await userManager.IsInRoleAsync(user, role.Name))
                    userRoleViewModel.IsSelected = true;
                else
                    userRoleViewModel.IsSelected = false;

                model.Add(userRoleViewModel);
            }
            return View(model);
        }

        [HttpPost]
        [Authorize(Policy = "ManageRolePolicy")]
        [Authorize(Policy = "ManageOtherUsersRolesPolicy")]
        public async Task<IActionResult> ManageUserRoles(List<UserRolesViewModel> model, string id)
        {
            ViewBag.UserId = id;

            var user = await userManager.FindByIdAsync(id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("ErrorPage");
            }

            var roles = await userManager.GetRolesAsync(user);
            var result = await userManager.RemoveFromRolesAsync(user, roles);

            if(!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot remove all existing roles");
                return View(model);
            }

            result = await userManager.AddToRolesAsync(user, model
                .Where(x => x.IsSelected).Select(x => x.RoleName));

            if(!result.Succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected roles to user");
                return View(model);
            }

            return RedirectToAction("EditUser", new { Id = id });
        }

        [Authorize(Policy = "ManageRolePolicy")]
        public async Task<IActionResult> EditClaims(string roleId)
        {
            ViewBag.RoleId = roleId;

            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("ErrorPage");
            }

            var model = new List<RoleClaimsViewModel>();
            var roleClaims = await roleManager.GetClaimsAsync(role);

            foreach (var claim in ClaimsStore.AllClaims)
            {
                var roleClaimsViewModel = new RoleClaimsViewModel
                {
                    ClaimType = claim.Type
                };

                if (roleClaims.Any(x => x.Type == claim.Type))
                    roleClaimsViewModel.IsSelected = true;
                else
                    roleClaimsViewModel.IsSelected = false;

                model.Add(roleClaimsViewModel);
            }
            return View(model);
        }

        [HttpPost]
        [Authorize(Policy = "ManageRolePolicy")]
        public async Task<IActionResult> EditClaims(List<RoleClaimsViewModel> model, string roleId)
        {
            ViewBag.roleId = roleId;

            var role = await roleManager.FindByIdAsync(roleId);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("ErrorPage");
            }

            bool succeeded = true;
            var claims = await roleManager.GetClaimsAsync(role);
            foreach (var claim in claims)
            {
                var temp = await roleManager.RemoveClaimAsync(role, claim);
                succeeded &= temp.Succeeded;
            }

            if (!succeeded)
            {
                ModelState.AddModelError("", "Cannot remove all existing claims");
                return View(model);
            }

            foreach(var claim in ClaimsStore.AllClaims)
            {
                if(model.Any(x => x.IsSelected && x.ClaimType == claim.Type))
                {
                    var temp = await roleManager.AddClaimAsync(role, claim);
                    succeeded &= temp.Succeeded;
                }
            }
            
            if (!succeeded)
            {
                ModelState.AddModelError("", "Cannot add selected claims to role");
                return View(model);
            }

            return RedirectToAction("EditRole", new { Id = roleId });
        }
    }
}
