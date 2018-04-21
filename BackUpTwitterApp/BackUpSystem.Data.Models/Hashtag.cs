using BlogSystem.Data.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BackUpSystem.Data.Models
{
    [Table("Hashtags")]
    public class Hashtag : DataModel
    {
        public Hashtag()
        {
            this.TweetHashtags = new HashSet<TweetHashtag>();
        }

        [Required]
        public string Text { get; set; }

        public ICollection<TweetHashtag> TweetHashtags { get; set; }
    }
}
