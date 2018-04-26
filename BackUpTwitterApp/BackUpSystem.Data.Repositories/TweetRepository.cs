using BackUpSystem.Data.Models;
using BackUpSystem.Data.Repositories.Contracts;
using BackUpSystem.Date.Repositories.Abstractions;
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

        public async void DownloadTweet(string userId, Tweet tweet)
        {
            throw new NotImplementedException();
        }

        public async void DeleteTweet(string userId, string tweetId)
        {
            throw new NotImplementedException();
        }
    }
}
