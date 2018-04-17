using BlogSystem.Data.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackUpSystem.Data.Models
{
    public class Tweet : DataModel
    {
        public Tweet()
        {
            this.Users = new HashSet<UserTweet>();
        }

        [DataType(DataType.DateTime)]
        public DateTime? CreatedAt { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string AuthorId { get; set; }

        //Corresponds to favorite_count in the Twitter API
        public int LikesCount { get; set; }

        public int RetweetCount { get; set; }

        public string Hashtag { get; set; }

        public string UserMentioned { get; set; }

        public string MediaUrl { get; set; }

        /// <summary>
        /// Navigation property - represents related entity
        /// </summary>
        public ICollection<UserTweet> Users { get; set; }

        /// <summary>
        /// Navigation property - represents related entity
        /// </summary>
        public string TwitterAccountId { get; set; }
        public TwitterAccount TwitterAccount { get; set; }
    }
}
