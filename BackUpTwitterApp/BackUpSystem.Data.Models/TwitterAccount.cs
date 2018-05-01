using BlogSystem.Data.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackUpSystem.Data.Models
{
    public class TwitterAccount : DataModel
    {
        public TwitterAccount()
        {
            this.Users = new HashSet<UserTwitterAccount>();
            this.Tweets = new HashSet<Tweet>();
        }

        //TwitterAccount Id corresponds to id_str from the Twitter API
        
        //Corresponds to screen_name from the Twitter API
        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Invalid UserName format!")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Invalid Name format!")]
        public string Name { get; set; }

        [StringLength(200, MinimumLength = 3, ErrorMessage = "Invalid Description format!")]
        public string Description { get; set; }

        public int FollowersCount { get; set; }

        //Corresponds to friends_count in Twitter API
        public int FollowingCount { get; set; }

        //Corresponds to favourites_count in Twitter API
        public int LikesCount { get; set; }

        //Corresponds to statuses_count in Twitter API
        public int TweetsCount { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? JoinedDate { get; set; }

        //Corresponds to profile_banner_url in Twitter API
        public string BackgroundImage { get; set; }

        public string WebsiteUrl { get; set; }

        public string ImageUrl { get; set; }

        /// <summary>
        /// Navigation property - represents related entity
        /// </summary>
        public ICollection<UserTwitterAccount> Users { get; set; }

        /// <summary>
        /// Navigation property - represents related entity
        /// </summary>
        public ICollection<Tweet> Tweets { get; set; }
    }
}
