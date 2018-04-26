using System;
using System.ComponentModel.DataAnnotations;
using BlogSystem.Data.Models.Abstracts;

namespace BackUpSystem.Data.Models
{
    public class UserTwitterAccount : IDeletable
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public string TwitterAccountId { get; set; }
        public TwitterAccount TwitterAccount { get; set; }

        public bool IsDeleted { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DeletedOn { get; set; }
    }
}
