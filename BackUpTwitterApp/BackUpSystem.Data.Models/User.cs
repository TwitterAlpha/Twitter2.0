using BlogSystem.Data.Models.Abstracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackUpSystem.Data.Models
{
    [Table("Users")]
    public class User : IdentityUser, IAuditable, IDeletable
    {
        public User()
        {
            this.FavoriteTweets = new HashSet<UserTweet>();
            this.TwitterAccounts = new HashSet<UserTwitterAccount>();
        }

        [StringLength(40, MinimumLength = 2, ErrorMessage = "Invalid Name format!")]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        [StringLength(100, MinimumLength = 2, ErrorMessage = "Invalid Description format!")]
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? BirthDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? JoinedDate { get; set; }

        [MinLength(20, ErrorMessage = "Invalid ImageUrl format!")]
        public string UserImageUrl { get; set; } = "https://pbs.twimg.com/profile_images/546708662287228929/XK0Jznql_400x400.jpeg";

        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }

        public int RetweetsCount { get; set; } // We can get admin statistics

        /// <summary>
        /// Navigation property - represents related entity
        /// </summary>
        public ICollection<UserTweet> FavoriteTweets { get; set; } // We can get admin statistics

        /// <summary>
        /// Navigation property - represents related entity
        /// </summary>
        public ICollection<UserTwitterAccount> TwitterAccounts { get; set; } // We can get admin statistics
    }
}
