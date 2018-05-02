using BackUpSystem.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace BackUpSystem.Web.Areas.Admin.Data
{
    public static class Seed
    {
        public static async Task CreateRoles(IServiceProvider serviceProvider, IConfiguration Configuration)
        {
            //adding customs roles
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var roleNames = new string[] { "Admin", "Member" };
            IdentityResult roleResult;
            
            foreach (var roleName in roleNames)
            {
                // creating the roles and seeding them to the database
                var roleExist = await RoleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            
            // creating a super user who could maintain the web app
            var admin = new User
            {
                UserName = Environment.GetEnvironmentVariable("adminUsername"),
                Email = Environment.GetEnvironmentVariable("adminUsername")
            };
            
            var userPassword = Environment.GetEnvironmentVariable("adminPassword");
            var user = await UserManager.FindByEmailAsync(Environment.GetEnvironmentVariable("adminUsername"));
            
            if (user == null)
            {
                var createPowerUser = await UserManager.CreateAsync(admin, userPassword);
                if (createPowerUser.Succeeded)
                {
                    // here we assign the new user the "Admin" role 
                    await UserManager.AddToRoleAsync(admin, "Admin");
                }
            }
        }
    }
}
