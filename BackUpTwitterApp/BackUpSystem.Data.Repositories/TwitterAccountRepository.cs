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

        public override async Task<TwitterAccount> Get(string id)
        {
            return await this.DbContext.TwitterAccounts
                .Include(u => u.Users)
                .Include(u => u.Tweets)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async void AddUserTwitterAccount(string userId, TwitterAccount twitterAccount)
        {
            var userCheck = await this.DbContext.Users.Include(x => x.TwitterAccounts).FirstOrDefaultAsync(x => x.Id == userId);

            if (userCheck != null)
            {
                var twitterAccountCheck = await this.DbContext.TwitterAccounts.FindAsync(twitterAccount.Id);

                if (twitterAccountCheck != null)
                {
                    if (await this.DbContext.UserTwitterAccounts.FindAsync(userId, twitterAccount.Id) != null)
                    {
                        twitterAccountCheck.IsDeleted = false;

                        var entry = this.DbContext.Entry(twitterAccountCheck);
                        entry.State = EntityState.Modified;

                        var userTwitterAccountToAdd = await this.DbContext.UserTwitterAccounts.FindAsync(userId, twitterAccount.Id);

                        if (userTwitterAccountToAdd != null)
                        {
                            userTwitterAccountToAdd.IsDeleted = false;
                        }
                    }
                    else
                    {
                        var userTwitterAccount = new UserTwitterAccount()
                        {
                            UserId = userId,
                            User = userCheck,
                            TwitterAccountId = twitterAccount.Id,
                            TwitterAccount = twitterAccount
                        };

                        await this.DbContext.UserTwitterAccounts.AddAsync(userTwitterAccount);
                    }
                }
                else
                {
                    base.Add(twitterAccount);

                    var userTwitterAccount = new UserTwitterAccount()
                    {
                        UserId = userId,
                        User = userCheck,
                        TwitterAccountId = twitterAccount.Id,
                        TwitterAccount = twitterAccount
                    };

                    await this.DbContext.UserTwitterAccounts.AddAsync(userTwitterAccount);
                }
            }
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
