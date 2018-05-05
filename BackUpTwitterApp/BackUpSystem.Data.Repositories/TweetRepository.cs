using BackUpSystem.Data.Models;
using BackUpSystem.Data.Repositories.Contracts;
using BackUpSystem.Date.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackUpSystem.Data.Repositories
{
    public class TweetRepository : Repository<Tweet>, ITweetRepository
    {
        public TweetRepository(BackUpSystemDbContext dbContext)
            : base(dbContext)
        {
        }

        //Override done, because of EF Core lazy-loading issue
        public override async Task<Tweet> Get(string id)
        {
            return await this.DbContext.Tweets
                .Include(u => u.TwitterAccount)
                .Include(u => u.Users)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<bool> DownloadTweet(string userId, Tweet tweet)
        {
            var isDownloaded = false;

            var user = await this.DbContext.Users.FindAsync(userId);

            if (user != null)
            {
                var userTweetExists = await this.DbContext.UserTweets.FindAsync(userId, tweet.Id);

                if (userTweetExists == null)
                {
                    var userTweet = new UserTweet()
                    {
                        UserId = userId,
                        User = user,
                        TweetId = tweet.Id,
                        Tweet = tweet
                    };

                    await this.DbContext.UserTweets.AddAsync(userTweet);

                    var tweetExists = await this.DbContext.Tweets.FindAsync(tweet.Id);

                    if (tweetExists != null)
                    {
                        if (tweetExists.IsDeleted)
                        {
                            tweetExists.IsDeleted = false;

                            var entry = this.DbContext.Entry(tweetExists);
                            entry.State = EntityState.Modified;
                        }
                    }
                    else
                    {
                        await this.DbContext.Tweets.AddAsync(tweet);
                    }

                    isDownloaded = true;
                }
                else
                {
                    if (userTweetExists.IsDeleted)
                    {
                        userTweetExists.IsDeleted = false;

                        var entry = this.DbContext.Entry(userTweetExists);
                        entry.State = EntityState.Modified;
                    }
                    isDownloaded = true;
                }
            }

            return isDownloaded;
        }

        public async Task<bool> UserTweetIsDeleted(string userId, string tweetId)
        {
            var isDeleted = false;
            var userTweetToDelete = await this.DbContext.UserTweets.FindAsync(userId, tweetId);

            if (userTweetToDelete != null)
            {
                userTweetToDelete.IsDeleted = true;
                userTweetToDelete.DeletedOn = DateTime.UtcNow;

                var entry = this.DbContext.Entry(userTweetToDelete);
                entry.State = EntityState.Modified;

                isDeleted = true;
            }

            return isDeleted;
        }

        public async void RetweetATweet(string userId)
        {
            var user = await this.DbContext.Users.FindAsync(userId);
            user.RetweetsCount++;
        }
    }
}
