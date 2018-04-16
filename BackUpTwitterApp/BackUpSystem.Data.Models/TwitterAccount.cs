using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BackUpSystem.Data.Models
{
    public class TwitterAccount
    {
        public TwitterAccount()
        {
            this.Tweets = new HashSet<Tweet>();
        }

        public int TwitterAccountId { get; set; }
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

        public User User { get; set; }

        public virtual ICollection<Tweet> Tweets { get; set; }
    }
}
