using BackUpSystem.Data.Models;
using BackUpSystem.DTO;
using BackUpSystem.DTO.ApiDtos;
using BackUpSystem.Utilities.Contracts;
using BackUpSystem.Web.Models.HomeViewModels;
using BackUpSystem.Services.Data.Contracts;
using Bytes2you.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace BackUpSystem.Web.Controllers
{
    [Authorize]
    public class DownloadedTweetsController : Controller
    {
        private readonly IUserService userService;
        private readonly UserManager<User> userManager;
        private readonly IMappingProvider mappingProvider;

        public DownloadedTweetsController(IUserService userService, UserManager<User> userManager, IMappingProvider mappingProvider)
        {
            Guard.WhenArgument(userService, "User Service").IsNull().Throw();
            Guard.WhenArgument(userManager, "User Manager").IsNull().Throw();
            Guard.WhenArgument(mappingProvider, "Mapping Provider").IsNull().Throw();

            this.userService = userService;
            this.userManager = userManager;
            this.mappingProvider = mappingProvider;
        }

        [ResponseCache(Duration = 300)]
        public async Task<IActionResult> Index()
        {
            var model = new TimelineViewModel();
            var userId = this.userManager.GetUserId(HttpContext.User);
            var tweets = await this.userService.GetAllDownloadTweetsByUser(userId);

            var downloadedTweets = this.mappingProvider.ProjectTo<TweetApiDto, TweetViewModel>(tweets).ToList();

            for (int i = 0; i < downloadedTweets.Count(); i++)
            {
                downloadedTweets[i].CanBeDeleted = true;
            }

            model.Tweets = downloadedTweets;

            return View(model);
        }
    }
}