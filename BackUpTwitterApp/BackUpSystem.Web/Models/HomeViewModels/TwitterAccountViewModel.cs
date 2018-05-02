using System;
using System.ComponentModel.DataAnnotations;

namespace BackUpSystem.Web.Models.HomeViewModels
{
    public class TwitterAccountViewModel
    {
        public string Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "Invalid UserName format!")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Invalid Name format!")]
        public string Name { get; set; }

        [StringLength(200, MinimumLength = 3, ErrorMessage = "Invalid Description format!")]
        public string Description { get; set; }

        public int FollowersCount { get; set; }

        public int FollowingCount { get; set; }

        public int LikesCount { get; set; }

        public int TweetsCount { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? JoinedDate { get; set; }

        public string BackgroundImage { get; set; }

        public string ImageUrl { get; set; }

        public bool IsInFavorites { get; set; }
    }
}
