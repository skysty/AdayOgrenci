using AdayOgrenci.Areas.Identity.Data;
using AdayOgrenci.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdayOgrenci.Controllers
{
    [Authorize(Policy = "AdminAccess")]
    public class RolesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AdayOgrenciAuthDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(
            AdayOgrenciAuthDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            var roles = _context.Roles.ToList();
            var users = _context.Users.ToList();
            var userRoles = _context.UserRoles.ToList();

            var convertedUsers = users.Select(x => new UsersViewModel
            {
                UserName = x.UserName,
                Roles = roles
                    .Where(y => userRoles.Any(z => z.UserId == x.Id && z.RoleId == y.Id))
                    .Select(y => new UsersRole
                    {
                        Name = y.NormalizedName
                    })
            });

            return View(new DisplayViewModel
            {
                Roles = roles.Select(x => x.NormalizedName),
                Users = convertedUsers
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(string username)
        {
            var user = new ApplicationUser
            {
                UserName = username
            };

            await _userManager.CreateAsync(user, "password");

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleViewModel vm)
        {
            await _roleManager.CreateAsync(new IdentityRole { Name = vm.Name });

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateUserRole(UpdateUserRoleViewModel vm)
        {
            var user = await _userManager.FindByNameAsync(vm.UserName);

            if (vm.Delete)
                await _userManager.RemoveFromRoleAsync(user, vm.Role);
            else
                await _userManager.AddToRoleAsync(user, vm.Role);

            return RedirectToAction("Index");
        }
    }

    public class DisplayViewModel
    {
        public IEnumerable<string> Roles { get; set; }
        public IEnumerable<UsersViewModel> Users { get; set; }
    }

    public class UsersViewModel
    {
        public string UserName { get; set; }
        public IEnumerable<UsersRole> Roles { get; set; }
    }

    public class UsersRole
    {
        public string Name { get; set; }
    }

    public class RoleViewModel
    {
        public string Name { get; set; }
    }

    public class UpdateUserRoleViewModel
    {
        public IEnumerable<UsersViewModel> Users { get; set; }
        public IEnumerable<string> Roles { get; set; }

        public string UserName { get; set; }
        public string Role { get; set; }
        public bool Delete { get; set; }
    }
}
