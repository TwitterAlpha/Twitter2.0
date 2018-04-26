using BackUpSystem.Data.Models;
using BackUpSystem.Data.Repositories.Contracts;
using BackUpSystem.Date.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackUpSystem.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(BackUpSystemDbContext dbContext)
            : base(dbContext)
        {
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await this.DbContext.Users
                .FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<IEnumerable<TwitterAccount>> GetAllFavoriteTwitterAccounts(string id)
        {
            return await this.DbContext.UserTwitterAccounts
                .Where(u => u.UserId == id)
                .Select(u => u.TwitterAccount)
                .ToListAsync();
        }

        public async Task<IEnumerable<Tweet>> GetAllDownloadedTweets(string id)
        {
            return await this.DbContext.UserTweets
                .Where(u => u.UserId == id)
                .Select(t => t.Tweet)
                .ToListAsync();
        }

        public async void UpdateName(string id, string name)
        {
            var user = await this.DbContext.Users.FindAsync(id);
            user.Name = name;
        }

        public async void UpdateBirthDate(string id, DateTime? birthDate)
        {
            var user = await this.DbContext.Users.FindAsync(id);
            user.BirthDate = birthDate;
        }

        public async void UpdateImageUrl(string id, string imageUrl)
        {
            var user = await this.DbContext.Users.FindAsync(id);
            user.UserImage = imageUrl;
        }
    }
}
