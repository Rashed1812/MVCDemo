using Demo.DAL.Models.IdentityModel;
using Demo.PL.Models.Roles;
using Demo.PL.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Demo.PL.Controllers
{
    public class RoleController(RoleManager<IdentityRole> _roleManager, IWebHostEnvironment _webHostEnvironment,UserManager<ApplicationUser> _userManager) : Controller
    {
        #region Index
        public async Task<IActionResult> Index(string SearchValue)
        {
            var rolesQuery = _roleManager.Roles.AsQueryable();
            if (!string.IsNullOrEmpty(SearchValue))
                rolesQuery = rolesQuery.Where(r => r.Name.ToLower().Contains(SearchValue.ToLower()));

            var rolesList = await rolesQuery.Select(r => new RoleViewModel
            {
                Id = r.Id,
                Name = r.Name
                //Roles = _userManager.GetRolesAsync(u).Result
            }).ToListAsync();
            return View(rolesList);
        }
        #endregion

        #region Details
        public async Task<IActionResult> Details(string? id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
                return NotFound();
            var roleViewModel = new RoleViewModel
            {
                Id = role.Id,
                Name = role.Name
            };
            return View(roleViewModel);
        }
        #endregion

        #region Edit
        [HttpGet]
        public async Task<IActionResult> Edit(string? id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
                return NotFound();
            var users = await _userManager.Users.ToListAsync();
            var roleViewModel = new RoleViewModel
            {
                Id = role.Id,
                Name = role.Name,
                Users = users.Select(u => new UserRoleViewModel
                {
                    UserId = u.Id,
                    UserName = u.UserName,
                    IsSelected = _userManager.IsInRoleAsync(u, role.Name).Result
                }).ToList()
            };
            return View(roleViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id,RoleViewModel roleViewModel)
        {
            if (!ModelState.IsValid)
                return View(roleViewModel);
            var message = string.Empty;
            try
            {
                var role = await _roleManager.FindByIdAsync(id);
                if (role == null)
                    return NotFound();
                role.Name = roleViewModel.Name;
                var result = await _roleManager.UpdateAsync(role);
                foreach (var userRole in roleViewModel.Users)
                {
                    var user = await _userManager.FindByIdAsync(userRole.UserId);
                    if (user == null)
                        return NotFound();
                    if (userRole.IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
                        await _userManager.AddToRoleAsync(user, role.Name);
                    else if (!userRole.IsSelected && (await _userManager.IsInRoleAsync(user, role.Name)))
                        await _userManager.RemoveFromRoleAsync(user, role.Name);
                }
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    message = "Role Can not be updated";
            }
            catch (Exception ex)
            {
                message = _webHostEnvironment.IsDevelopment() ? ex.Message : "Role Can not be updated";
            }
            return View(roleViewModel);
        }
        #endregion

        #region Delete
        [HttpGet]
        public async Task<IActionResult> Delete(string? id)
        {
            if (string.IsNullOrEmpty(id))
                return BadRequest();
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
                return NotFound();
            var roleViewModel = new RoleViewModel
            {
                Id = role.Id,
                Name = role.Name
            };
            return View(roleViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            var message = string.Empty;
            try
            {
                if (role == null)
                    return NotFound();
                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                {
                    message = "Role Can not be deleted";
                }
            }
            catch (Exception ex)
            {
                message = _webHostEnvironment.IsDevelopment() ? ex.Message : "Role Can not be deleted";
            }
            ModelState.AddModelError(string.Empty, message);
            return View(nameof(Index));
        }
        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoleViewModel roleViewModel)
        {
            if (!ModelState.IsValid)
                return View(roleViewModel);
            var message = string.Empty;
            try
            {
                var role = new IdentityRole
                {
                    Name = roleViewModel.Name
                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                {
                    message = "Role Can not be created";
                }
            }
            catch (Exception ex)
            {
                message = _webHostEnvironment.IsDevelopment() ? ex.Message : "Role Can not be created";
            }
            ModelState.AddModelError(string.Empty, message);
            return View(roleViewModel);
        }
        #endregion

    }
}
