using BackUpSystem.DTO;
using BackUpSystem.Utilities.Contracts;
using BackUpSystem.Web.Models.HomeViewModels;
using BackUpSystem.Web.Models.SearchViewModels;
using BackUpSystem.Services.Data.Contracts;
using Bytes2you.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackUpSystem.Web.Controllers
{
    public class SearchController : Controller
    {
        private readonly ITwitterService twitterService;
        private readonly IMappingProvider mappingProvider;

        public SearchController(ITwitterService twitterService, IMappingProvider mappingProvider)
        {
            Guard.WhenArgument(twitterService, "Twitter Service").IsNull().Throw();
            Guard.WhenArgument(mappingProvider, "Mapping Provider").IsNull().Throw();

            this.twitterService = twitterService;
            this.mappingProvider = mappingProvider;
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Load(SearchViewModel requestModel)
        {
            if (ModelState.IsValid)
            {
                var viewModel = new SearchResultViewModel();
                var searchResult = await twitterService.SearchUsersByScreenName(requestModel.UserInput);
                viewModel.SearchResult = this.mappingProvider.ProjectTo<TwitterAccountApiDto, TwitterAccountViewModel>(searchResult);

                return this.PartialView("_SearchPartial", viewModel);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
