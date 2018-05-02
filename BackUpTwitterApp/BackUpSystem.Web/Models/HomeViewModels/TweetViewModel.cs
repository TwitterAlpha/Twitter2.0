using System;
using System.ComponentModel.DataAnnotations;

namespace BackUpSystem.Web.Models.HomeViewModels
{
    public class TweetViewModel
    {
        public string Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreatedAt { get; set; }

        [Required]
        public string Text { get; set; }

        public string TweetAuthor { get; set; }

        public string TweetUrl { get; set; }
 
        public int LikesCount { get; set; }

        public int RetweetCount { get; set; }

        public string MediaUrl { get; set; }

        public bool CanBeDeleted { get; set; }

        public bool IsDownloaded { get; set; }
    }
}
