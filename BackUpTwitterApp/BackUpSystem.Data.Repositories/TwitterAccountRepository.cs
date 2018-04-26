using BackUpSystem.Data.Models;
using BackUpSystem.Data.Repositories.Contracts;
using BackUpSystem.Date.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BackUpSystem.Data.Repositories
{
    public class TwitterAccountRepository : Repository<TwitterAccount>, ITwitterAccountRepository
    {
        public TwitterAccountRepository(BackUpSystemDbContext dbContext)
            : base(dbContext)
        {
        }

        public async void AddTwitterAccountToUser(UserTwitterAccount twitterAccount, string userId)
        {
            var test = await this.DbContext.Users.Include(x => x).FirstOrDefaultAsync(x => x.Id == userId);
        }
    }
}
