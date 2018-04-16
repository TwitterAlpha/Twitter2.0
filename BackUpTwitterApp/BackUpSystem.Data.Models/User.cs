using BlogSystem.Data.Models.Abstracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BackUpSystem.Data.Models
{
    public class User : IdentityUser, IAuditable, IDeletable
    {
        public User()
        {
            this.Tweets = new HashSet<Tweet>();
            this.FavoriteTwitterAccounts = new HashSet<TwitterAccount>();
        }
        [Key]
        public int UserId { get; set; }

        public bool IsDeleted { get; set; }

        //[Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        //public string Username { get; set; } 

        //[Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        //public string Password { get; set; }

        //[Required]
        //[EmailAddress]
        //public override string Email { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string FirstName { get; set; }

        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string LastName { get; set; }

        public bool IsAdmin { get; set; } //Must be done by Role - string

        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }

        public int ReTweetsCount { get; set; } // We can get admin statistics
        public virtual ICollection<Tweet> Tweets { get; set; } // We can get admin statistics

        //[NotMapped]
        public virtual ICollection<TwitterAccount> FavoriteTwitterAccounts { get; set; } // We can get admin statistics
    }
} 
