﻿using BlogProjesi.Areas.Admin.Models;
using BlogProjesi.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogProjesi.Areas.Admin.Controllers
{
    [Area("Admin")]
   // [Authorize(Roles ="Admin")] // erişim sağlayacak kişiler seçilir. 
    public class AdminRolController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public AdminRolController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            // verileri listelemek için 
            var values = _roleManager.Roles.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppRole role = new AppRole
                {
                    Name = model.Name
                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var item in result.Errors)
                {

                    ModelState.AddModelError("", item.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            RoleUpdateViewModel model = new RoleUpdateViewModel
            {
                Id = values.Id,
                Name = values.Name
            };
            return View(model);

        }


        [HttpPost]
        public async Task<IActionResult> UpdateRole(RoleUpdateViewModel model)
        {

            var values = _roleManager.Roles.Where(x => x.Id == model.Id).FirstOrDefault();
            values.Name = model.Name;
            var result = await _roleManager.UpdateAsync(values);
            if (result.Succeeded)
            {

                return RedirectToAction("Index");
            }
            return View(model);

        }


        public async Task<IActionResult> DeleteRole(int id)
        {

            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var result = await _roleManager.DeleteAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult UserRoleList()
        {
            var values = _userManager.Users.ToList();   
            return View(values);
        }


        [HttpGet]

        public async Task< IActionResult >AssignRole  (int id)
        {

            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);  
            var roles = _roleManager.Roles.ToList();

            TempData["UserId"] = user.Id;

            var userRoles = await _userManager.GetRolesAsync(user);

            List<RoleAssignViewModel> model = new List<RoleAssignViewModel>();

            foreach (var item  in roles )
            {
                RoleAssignViewModel rm = new RoleAssignViewModel();
                rm.RoleID = item.Id;
                rm.Name = item.Name;
                rm.Exists = userRoles.Contains(item.Name);
                model.Add(rm);  
            }
            return View(model);
        }

        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
        {
            var userid = (int)TempData["UserId"];
            var User = _userManager.Users.FirstOrDefault(x => x.Id == userid);
            foreach (var item in model)
            {
                if (item.Exists)
                {
                    await _userManager.AddToRoleAsync(User, item.Name);

                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(User, item.Name);
                }
            }
            return RedirectToAction("UserRoleList");

        }
    }
}