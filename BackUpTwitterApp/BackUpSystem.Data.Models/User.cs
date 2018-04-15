using BlogSystem.Data.Models.Abstracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackUpSystem.Data.Models
{
    public class User : IdentityUser, IAuditable, IDeletable
    {
        public User()
        {
            this.Tweets = new List<Tweet>();
            this.FavoriteTwitterAccounts = new List<string>();
        }

        public bool IsDeleted { get; set; }

        [Key]
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Username { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [EmailAddress]
        public override string Email { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string FirstName { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string LastName { get; set; }

        public bool IsAdmin { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }

        public int ReTweetsCount { get; set; } // We can get admin statistics
        public ICollection<Tweet> Tweets { get; set; } // We can get admin statistics
        public ICollection<string> FavoriteTwitterAccounts { get; set; } // We can get admin statistics
    }
}
