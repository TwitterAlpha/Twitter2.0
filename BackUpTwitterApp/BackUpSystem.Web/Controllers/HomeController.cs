using BackUpSystem.Data.Models;
using BackUpSystem.DTO;
using BackUpSystem.DTO.ApiDtos;
using BackUpSystem.Services.Data.Contracts;
using BackUpSystem.Utilities.Contracts;
using BackUpSystem.Web.Models;
using BackUpSystem.Web.Models.HomeViewModels;
using BackUpSystem.Web.Models.SearchViewModels;
using Bytes2you.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BackUpSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly UserManager<User> userManager;
        private readonly IMappingProvider mappingProvider;
        private readonly ITwitterService twitterService;

        public HomeController(IUserService userService, UserManager<User> userManager, IMappingProvider mappingProvider, ITwitterService twitterService)
        {
            Guard.WhenArgument(userService, "User Service").IsNull().Throw();
            Guard.WhenArgument(userManager, "User Manager").IsNull().Throw();
            Guard.WhenArgument(mappingProvider, "Mapping Provider").IsNull().Throw();

            this.userService = userService;
            this.userManager = userManager;
            this.mappingProvider = mappingProvider;
            this.twitterService = twitterService;
        }

        public async Task<IActionResult> Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var model = new TimelineViewModel();
                var userId = this.userManager.GetUserId(this.HttpContext.User);
                var tweets = await this.userService.GetTimeline(userId);

                var timelineTweets = this.mappingProvider.ProjectTo<TweetApiDto, TweetViewModel>(tweets).ToList();
                var downladedTweets = await this.userService.GetAllDownloadTweetsByUser(userId);

                foreach (var tweet in downladedTweets)
                {
                    for (int i = 0; i < timelineTweets.Count(); i++)
                    {
                        if (tweet.Id == timelineTweets[i].Id)
                        {
                            timelineTweets[i].IsDownloaded = true;
                        }
                    }
                }
                model.Tweets = timelineTweets;

                return View(model);
            }

            return RedirectToAction("About");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search(SearchViewModel requestModel)
        {
            if (ModelState.IsValid)
            {
                var viewModel = new SearchResultViewModel();
                var searchResult = await twitterService.SearchUsersByScreenName(requestModel.UserInput);
                var foundUsers = this.mappingProvider.ProjectTo<TwitterAccountApiDto, TwitterAccountViewModel>(searchResult).ToList();

                var userId = this.userManager.GetUserId(this.HttpContext.User);
                var favoriteUsers = await userService.GetAllFavoriteTwitterAccounts(userId);

                foreach (var favUser in favoriteUsers)
                {
                    for (int i = 0; i < foundUsers.Count(); i++)
                    {
                        foundUsers[i].ImageUrl = foundUsers[i].ImageUrl.Replace("_normal", string.Empty);

                        if (favUser.Id == foundUsers[i].Id)
                        {
                            foundUsers[i].IsInFavorites = true;
                        }
                    }
                }

                viewModel.SearchResult = foundUsers;

                return this.View("_SearchPartial", viewModel);
            }

            return RedirectToAction("Index");
        }
    }
}
