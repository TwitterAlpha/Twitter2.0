using BackUpSystem.Data.Models;
using BackUpSystem.DTO;
using BackUpSystem.DTO.ApiDtos;
using BackUpSystem.Services.Data.Contracts;
using BackUpSystem.Utilities.Contracts;
using BackUpSystem.Web.Models.HomeViewModels;
using Bytes2you.Validation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BackUpSystem.Web.Controllers
{
    public class TwitterAccountController : Controller
    {
        private readonly ITwitterService twitterService;
        private readonly ITwitterAccountService twitterAccountService;
        private readonly IUserService userService;
        private readonly IMappingProvider mappingProvider;
        private readonly UserManager<User> userManager;

        public TwitterAccountController(ITwitterService twitterService, ITwitterAccountService twitterAccountService, IUserService userService, IMappingProvider mappingProvider, UserManager<User> userManager)
        {
            Guard.WhenArgument(twitterService, "Twitter Service").IsNull().Throw();
            Guard.WhenArgument(twitterAccountService, "TwitterAccount Service").IsNull().Throw();
            Guard.WhenArgument(userService, "User Service").IsNull().Throw();
            Guard.WhenArgument(mappingProvider, "Mapping Provider").IsNull().Throw();
            Guard.WhenArgument(userManager, "User Manager").IsNull().Throw();

            this.twitterService = twitterService;
            this.twitterAccountService = twitterAccountService;
            this.userService = userService;
            this.mappingProvider = mappingProvider;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index(TwitterAccountViewModel model)
        {
            var timelineViewModel = new TimelineViewModel();
            var userTimeline = await twitterService.GetUsersTimeline(model.Id);
            Guard.WhenArgument(userTimeline, "User Timeline").IsNull().Throw();

            var twitterAccountTimeline = this.mappingProvider.ProjectTo<TweetApiDto, TweetViewModel>(userTimeline).ToList();
            var userId = this.userManager.GetUserId(this.HttpContext.User);
            var downloadedTweets = await this.userService.GetAllDownloadTweetsByUser(userId);

            foreach (var tweet in downloadedTweets)
            {
                for (int i = 0; i < twitterAccountTimeline.Count(); i++)
                {
                    if (tweet.Id == twitterAccountTimeline[i].Id)
                    {
                        twitterAccountTimeline[i].IsDownloaded = true;
                    }
                }
            }

            timelineViewModel.Tweets = twitterAccountTimeline;
            timelineViewModel.TwiitterAccountInfo = model;

            return View(timelineViewModel);
        }

        public async Task<IActionResult> AddTwitterAccountToFavorites([FromBody]TwitterAccountViewModel model)
        {
            var userId = this.userManager.GetUserId(this.HttpContext.User);

            if (model.BackgroundImage == null)
            {
                model.BackgroundImage = "https://www.smartt.com/sites/default/files/public/twitter_logo_banner_12.jpg";
            }

            var twitterAccountToaAdd = this.mappingProvider.MapTo<TwitterAccountApiDto>(model);

            await this.twitterAccountService.AddTwitterAccountToUser(twitterAccountToaAdd, userId);

            return Json($"You just followed {model.Name}!");
        }

        public async Task<IActionResult> DeleteTwitterAccountFromFavorites([FromBody]TwitterAccountViewModel model)
        {
            var userId = this.userManager.GetUserId(this.HttpContext.User);

            var twitterAccountToaAdd = this.mappingProvider.MapTo<TwitterAccountApiDto>(model);

            await this.twitterAccountService.DeleteTwitterAccountFromUser(userId, model.Id);

            return Json($"{model.Name} successfully unfollowed!");
        }
    }
}