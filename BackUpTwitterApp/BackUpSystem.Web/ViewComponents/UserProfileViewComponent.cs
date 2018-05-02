using BackUpSystem.Data.Models;
using BackUpSystem.Utilities.Contracts;
using BackUpSystem.Web.Models.HomeViewModels;
using BackUpSystem.Services.Data.Contracts;
using Bytes2you.Validation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackUpSystem.Web.ViewComponents
{
    public class UserProfileViewComponent : ViewComponent
    {
        private readonly IUserService userService;
        private readonly IMappingProvider mappingProvider;
        private readonly UserManager<User> userManager;

        public UserProfileViewComponent(IUserService userService, IMappingProvider mappingProvider, UserManager<User> userManager)
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
            var model = new UserProfileViewModel();
            var userId = this.userManager.GetUserId(this.HttpContext.User);
            var user = await userService.GetUserById(userId);

            model = this.mappingProvider.MapTo<UserProfileViewModel>(user);

            return View(model);
        }
    }
}
