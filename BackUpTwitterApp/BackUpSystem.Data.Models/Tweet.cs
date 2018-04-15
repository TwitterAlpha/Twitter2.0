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
        public Tweet()
        {
            this.Comments = new HashSet<Comment>();
        }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        [Required]
        public User Author { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
