using BackUpSystem.Services.Data.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackUpSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserManagementController : Controller
    {
        private readonly IUserService userService;

        public UserManagementController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> Index()
        {

            var users = await this.userService.GetAllUsers();

            return View(users);
        }

        public async Task<IActionResult> Details(string id)
        {
            var user = await this.userService.GetUserById(id);
            return View(user);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var user = await this.userService.GetUserById(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateName(string id, string Name)
        {
            await this.userService.UpdateName(id, Name);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete (string id)
        {
            await this.userService.DeleteUser(id);

            return RedirectToAction("Index");
        }
    }
}