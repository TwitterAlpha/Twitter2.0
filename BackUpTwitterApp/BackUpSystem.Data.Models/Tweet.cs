using BlogSystem.Data.Models;
using BlogSystem.Data.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackUpSystem.Data.Models
{
    public class Tweet: DataModel
    {
        public int TweetId { get; set; }
        public string IdString { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Text { get; set; }
        public string AuthorId { get; set; }
        public int ReTweetCount { get; set; }
        public int FavoriteCount { get; set; }
        public string Language { get; set; }

        public User User { get; set; }
        public TwitterAccount TwitterAccount { get; set; }
    }
}
