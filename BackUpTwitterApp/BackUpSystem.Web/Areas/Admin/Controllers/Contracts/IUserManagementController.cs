using BackUpSystem.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackUpSystem.Web.Areas.Admin.Controllers.Contracts
{
    interface IUserManagementController
    {
        Task<IActionResult> Index();

        Task<IActionResult> Details(string id);

        Task<IActionResult> Edit(string id);

        Task<IActionResult> Edit(EditViewModel model);

        Task<IActionResult> Delete(string id);

        Task<IActionResult> DeleteTwitterAccount(string userId, string twitterAccountId);

        Task<IActionResult> DeleteTweet(string userId, string tweetId);
    }
}
