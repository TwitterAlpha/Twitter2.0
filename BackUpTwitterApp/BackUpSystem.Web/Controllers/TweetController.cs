using BackUpSystem.Data.Models;
using BackUpSystem.DTO.ApiDtos;
using BackUpSystem.Utilities.Contracts;
using BackUpSystem.Web.Models.HomeViewModels;
using BackUpSystem.Services.Data.Contracts;
using Bytes2you.Validation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace BackUpSystem.Web.Controllers
{
    public class TweetController : Controller
    {
        private readonly ITweetService tweetService;
        private readonly UserManager<User> userManager;
        private readonly IMappingProvider mappingProvider;

        public TweetController(ITweetService tweetService, UserManager<User> userManager, IMappingProvider mappingProvider)
        {
            Guard.WhenArgument(tweetService, "Tweet Service").IsNull().Throw();
            Guard.WhenArgument(userManager, "User Manager").IsNull().Throw();
            Guard.WhenArgument(mappingProvider, "Mapping Provider").IsNull().Throw();

            this.tweetService = tweetService;
            this.userManager = userManager;
            this.mappingProvider = mappingProvider;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Download([FromBody]TweetViewModel model)
        {
            var userId = this.userManager.GetUserId(this.HttpContext.User);

            var tweet = this.mappingProvider.MapTo<TweetApiDto>(model);
            Guard.WhenArgument(tweet, "Tweet").IsNull().Throw();

            var downloadedSuccessfully = await tweetService.DownloadTweet(userId, tweet);

            if (downloadedSuccessfully)
            {
                return Json("Tweet successfully added to Downloaded tweets!");
            }
            return Json("Tweet could not be downloaded!");

        }

        [Authorize]
        public IActionResult Retweet(string tweetId)
        {
            var userId = this.userManager.GetUserId(this.HttpContext.User);
            var retweetUrl = tweetService.RetweetATweet(userId, tweetId);

            return Redirect(retweetUrl);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Delete([FromBody]TweetViewModel model)
        {
            var userId = this.userManager.GetUserId(this.HttpContext.User);
            var deletedSuccessfully = await tweetService.DeleteTweet(userId, model.Id);

            if (deletedSuccessfully)
            {
                return Json("Tweet successfully deleted!");
            }

            return Json("Tweet could not be deleted!");
        }
    }
}