using BackUpSystem.Services.Data.Contracts;
using BackUpSystem.Web.Areas.Admin.Controllers.Contracts;
using BackUpSystem.Web.Areas.Admin.Models;
using Bytes2you.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackUpSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserManagementController : Controller, IUserManagementController
    {
        private readonly IUserService userService;
        private readonly ITwitterAccountService twitterAccountService;
        private readonly ITweetService tweetService;

        public UserManagementController(
            IUserService userService,
            ITwitterAccountService twitterAccountService,
            ITweetService tweetService
            )
        {
            Guard.WhenArgument(userService, "User Service").IsNull().Throw();
            this.userService = userService;

            Guard.WhenArgument(twitterAccountService, "Twitter Account Service").IsNull().Throw();
            this.twitterAccountService = twitterAccountService;

            Guard.WhenArgument(tweetService, "Tweet Service").IsNull().Throw();
            this.tweetService = tweetService;
        }

        public async Task<IActionResult> Index()
        {

            var users = await this.userService.GetAllUsers();

            return View("Index", users);
        }

        public async Task<IActionResult> Details(string id)
        {
            var user = await this.userService.GetUserById(id);
            var twitterAccounts = await this.userService.GetAllFavoriteTwitterAccounts(id);
            var tweets = await this.userService.GetAllDownloadTweetsByUser(id);
            var detailsViewModel = new UserDetailsModel()
            {
                User = user,
                TwitterAccounts = twitterAccounts,
                Tweets = tweets
            };
            return View("Details", detailsViewModel);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var user = await this.userService.GetUserById(id);
            var viewModel = new EditViewModel
            {
                Id = user.Id,
                Name = user.Name,
                BirthDate = user.BirthDate,
                UserImageUrl = user.UserImageUrl,
                IsAdmin = user.IsAdmin
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return View(model);
            }

            var user = await this.userService.GetUserById(model.Id);
            if (user == null)
            {
                return RedirectToAction("Index");
            }

            if (model.BirthDate != user.BirthDate)
            {
                await this.userService.UpdateBirthDate(model.Id, model.BirthDate);
            }

            if (model.Name != user.Name)
            {
                await this.userService.UpdateName(model.Id, model.Name);
            }

            if (model.UserImageUrl != user.UserImageUrl)
            {
                await this.userService.UpdateProfileImage(model.Id, model.UserImageUrl);
            }

            if (model.IsAdmin != user.IsAdmin)
            {
                await this.userService.UpdateIsAdmin(model.Id, model.IsAdmin);
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete (string id)
        {
            await this.userService.DeleteUser(id);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTwitterAccount(string userId, string twitterAccountId)
        {
            await this.twitterAccountService.DeleteTwitterAccountFromUser(userId, twitterAccountId);

            return RedirectToAction("Details", new { id = userId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>  DeleteTweet(string userId, string tweetId)
        {
            await this.tweetService.DeleteTweet(userId, tweetId);

            return RedirectToAction("Details", new { id = userId });
        }
    }
}