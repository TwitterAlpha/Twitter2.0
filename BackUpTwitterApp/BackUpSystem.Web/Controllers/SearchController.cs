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

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Go(SearchViewModel request)
        {
            var searchResult = twitterService.SearchUsersByScreenName(request.UserInput);

            var viewModel = new SearchResultViewModel();
            viewModel.SearchResult = await searchResult;

            return View("List", viewModel);
        }
    }
}
