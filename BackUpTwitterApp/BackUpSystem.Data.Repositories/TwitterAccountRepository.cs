using BackUpSystem.Data.Models;
using BackUpSystem.Data.Repositories.Contracts;
using BackUpSystem.Date.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BackUpSystem.Data.Repositories
{
    public class TwitterAccountRepository : Repository<TwitterAccount>, ITwitterAccountRepository
    {
        public TwitterAccountRepository(BackUpSystemDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<bool> UserTwitterAccountIsDeleted(string userId, string twitterAccountId)
        {
            var isDeleted = false;
            var userTwitterAccountToDelete = await this.DbContext.UserTwitterAccounts.FindAsync(userId, twitterAccountId);

            if (userTwitterAccountToDelete != null)
            {
                userTwitterAccountToDelete.IsDeleted = true;
                userTwitterAccountToDelete.DeletedOn = DateTime.UtcNow;

                var entry = this.DbContext.Entry(userTwitterAccountToDelete);
                entry.State = EntityState.Modified;

                isDeleted = true;
            }

            return isDeleted;
        }
    }
}
