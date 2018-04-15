using System;
using System.Collections.Generic;
using System.Text;

namespace BackUpSystem.Data.Models
{
    public class TwitterAccount
    {
        public TwitterAccount()
        {
            this.Tweets = new List<Tweet>();
        }

        public string TwitterIdStr { get; set; }
        public string Name { get; set; }
        public string ScreenName { get; set; }
        public int FollowerCount { get; set; }
        public int FriendsCount { get; set; }
        public int ListedCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public int FavouritesCount { get; set; }
        public int StatusesCount { get; set; }
        public string ImageUrl { get; set; }


        IEnumerable<Tweet> Tweets { get; set; }
    }
}
