using BlogSystem.Data.Models.Abstracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace BackUpSystem.Data.Models
{
    public class UserTweet : IDeletable, IAuditable
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public string TweetId { get; set; }
        public Tweet Tweet { get; set; }

        public bool IsDeleted { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? ModifiedOn { get; set; }
    }
}
