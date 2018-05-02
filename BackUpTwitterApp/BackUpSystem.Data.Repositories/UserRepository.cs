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

        //Override done, because of EF Core lazy-loading issue
        public override async Task<User> Get(string id)
        {
            return await this.DbContext.Users
                .Include(u => u.TwitterAccounts)
                .Include(u => u.FavoriteTweets)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await this.DbContext.Users
                .FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<IEnumerable<TwitterAccount>> GetAllFavoriteTwitterAccounts(string id)
        {
            return await this.DbContext.UserTwitterAccounts
                .Where(ut => !ut.IsDeleted)
                .Include(x => x.User)
                .Include(x => x.TwitterAccount)
                .Where(u => u.UserId == id && !u.IsDeleted)
                .Select(u => u.TwitterAccount)
                .Where(t => !t.IsDeleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<Tweet>> GetAllDownloadedTweets(string id)
        {
            return await this.DbContext.UserTweets
                .Where(ut => !ut.IsDeleted)
                .Include(x => x.User)
                .Include(x => x.Tweet)
                .Where(u => u.UserId == id)
                .Select(t => t.Tweet)
                .Where(t => !t.IsDeleted)
                .ToListAsync();
        }

        public async Task<bool> TwitterAccountAddedToUser(User user, TwitterAccount twitterAccount)
        {
            var checkIfTwitterAccountExists = await this.DbContext.UserTwitterAccounts.FindAsync(user.Id, twitterAccount.Id);

            if (checkIfTwitterAccountExists != null)
            {
                checkIfTwitterAccountExists.IsDeleted = false;
                return true;
            }
            else
            {
                var userTwitterAccount = new UserTwitterAccount()
                {
                    UserId = user.Id,
                    User = user,
                    TwitterAccountId = twitterAccount.Id,
                    TwitterAccount = twitterAccount
                };
                this.DbContext.UserTwitterAccounts.Add(userTwitterAccount);
                return true;
            }
        }

        public async Task<bool> TweetDownloaded(User user, Tweet tweet)
        {
            var checkIfTweetExists = await this.DbContext.UserTweets.FindAsync(user.Id, tweet.Id);

            if (checkIfTweetExists != null)
            {
                checkIfTweetExists.IsDeleted = false;
                return true;
            }
            else
            {
                var userTweet = new UserTweet()
                {
                    UserId = user.Id,
                    User = user,
                    TweetId = tweet.Id,
                    Tweet = tweet
                };
                this.DbContext.UserTweets.Add(userTweet);
                return true;
            }
        }

        public async void DeleteUserFromOtherTables(string userId)
        {
            var userTwitterAccount = await this.DbContext.UserTwitterAccounts.FirstOrDefaultAsync(x => x.UserId == userId);

            if (userTwitterAccount != null)
            {
                userTwitterAccount.IsDeleted = true;
                userTwitterAccount.DeletedOn = DateTime.Now;

                var entry = this.DbContext.Entry(userTwitterAccount);
                entry.State = EntityState.Modified;
            }

            var userTweet = await this.DbContext.UserTwitterAccounts.FirstOrDefaultAsync(x => x.UserId == userId);

            if (userTweet != null)
            {
                userTweet.IsDeleted = true;
                userTweet.DeletedOn = DateTime.Now;

                var entry = this.DbContext.Entry(userTweet);
                entry.State = EntityState.Modified;
            }
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
            user.UserImageUrl = imageUrl;
        }

        //public void IncludeFavoriteTwitterAccounts()
        //{
        //    this.DbContext.Users.Include(x => x.TwitterAccounts);
        //}

        //public void IncludeFavoriteTweets()
        //{
        //    this.DbContext.Users.Include(x => x.FavoriteTweets);
        //}
    }
}
