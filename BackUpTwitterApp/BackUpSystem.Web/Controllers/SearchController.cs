using BackUpSystem.Web.Models.SearchViewModels;
using BackUpSytem.Services.Data.Contracts;
using Bytes2you.Validation;
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
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Go(SearchViewModel requestModel)
        {
            if (ModelState.IsValid)
            {
                var searchResult = twitterService.SearchUsersByScreenName(requestModel.UserInput);

                var viewModel = new SearchResultViewModel();
                viewModel.SearchResult = await searchResult;


                TempData["Success-Message"] = "Results found:";
                return View("List", viewModel);
            }

            return this.View(requestModel);
        }
    }
}
