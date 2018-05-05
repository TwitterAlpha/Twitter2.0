using BackUpSystem.Data.Models;
using BackUpSystem.DTO;
using BackUpSystem.Services.Data.Contracts;
using BackUpSystem.Utilities.Contracts;
using BackUpSystem.Web.Models.HomeViewModels;
using Bytes2you.Validation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackUpSystem.Web.ViewComponents
{
    public class FavoriteTwitterAccountsViewComponent : ViewComponent
    {
        private readonly IUserService userService;
        private readonly IMappingProvider mappingProvider;
        private readonly UserManager<User> userManager;

        public FavoriteTwitterAccountsViewComponent(
            IUserService userService,
            IMappingProvider mappingProvider, 
            UserManager<User> userManager)
        {
            Guard.WhenArgument(userService, "User Service can not be null!").IsNull().Throw();
            Guard.WhenArgument(mappingProvider, "Mapping Provider can not be null!").IsNull().Throw();
            Guard.WhenArgument(userManager, "User Manager can not be null!").IsNull().Throw();

            this.userService = userService;
            this.mappingProvider = mappingProvider;
            this.userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = new FavoriteTwitterAccountsViewModel();
            var userId = this.userManager.GetUserId(this.HttpContext.User);
            var favoriteTwitterAccounts = await userService.GetAllFavoriteTwitterAccounts(userId);

            model.TwitterAccounts = this.mappingProvider.ProjectTo<TwitterAccountDto, TwitterAccountViewModel>(favoriteTwitterAccounts);

            return View(model);
        }
    }
}
