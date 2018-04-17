using BlogSystem.Data.Models.Abstracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackUpSystem.Data.Models
{
    public class User : IdentityUser, IAuditable, IDeletable
    {
        public User()
        {
            this.FavoriteTweets = new HashSet<UserTweet>();
            this.TwitterAccounts = new HashSet<UserTwitterAccount>();
        }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Invalid First Name format!")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Invalid Last Name format!")]
        public string LastName { get; set; }

        public bool IsDeleted { get; set; }

        public struct Info
        {
            public string Description { get; set; }

            [DataType(DataType.DateTime)]
            public DateTime? BirthDate { get; set; }

            [DataType(DataType.DateTime)]
            public DateTime? JoinedDate { get; set; }
        }

        public string UserImage { get; set; }

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
