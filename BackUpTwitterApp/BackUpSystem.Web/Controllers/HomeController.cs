using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackUpSystem.Web.Models;
using BackUpSytem.Services.Data.Contracts;
using Bytes2you.Validation;
using BackUpSystem.Web.Models.HomeViewModels;
using Microsoft.AspNetCore.Identity;
using BackUpSystem.Data.Models;
using BackUpSystem.Utilities.Contracts;
using BackUpSystem.DTO.ApiDtos;
using BackUpSystem.DTO;

namespace BackUpSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly UserManager<User> userManager;
        private readonly IMappingProvider mappingProvider;
        private readonly ITwitterAccountService twitterService;

        public HomeController(IUserService userService, UserManager<User> userManager, IMappingProvider mappingProvider, ITwitterAccountService twitterService)
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

                model.Tweets = this.mappingProvider.ProjectTo<TweetApiDto, TweetViewModel>(tweets);

                return View(model);
            }

            return RedirectToAction("About");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
