using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackUpSystem.Services.Data.Contracts;
using BackUpSystem.Web.Areas.Admin.Controllers.Contracts;
using Bytes2you.Validation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackUpSystem.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class StatisticsController : Controller, IStatisticsController
    {
        private readonly IUserService userService;

        public StatisticsController(IUserService userService)
        {
            Guard.WhenArgument(userService, "User Service").IsNull().Throw();
            this.userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            var users = await this.userService.GetAllUsers();

            return View(users);
        }
    }
}