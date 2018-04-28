using BackUpSystem.Web.Models.SearchViewModels;
using BackUpSytem.Services.Data.Contracts;
using Bytes2you.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackUpSystem.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly ITwitterService twitterService;

        public SearchController(ITwitterService twitterService)
        {
            Guard.WhenArgument(twitterService, "Twitter Service").IsNull().Throw();
            this.twitterService = twitterService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Load(SearchViewModel requestModel)
        {
            if (ModelState.IsValid)
            {
                var searchResult = twitterService.SearchUsersByScreenName(requestModel.UserInput);

                var viewModel = new SearchResultViewModel();
                viewModel.SearchResult = await searchResult;

                TempData["Success-Message"] = "Results found:";

                return View("_SearchResultPartial", viewModel);
            }

            return this.View("Index",requestModel);
        }
    }
}
 