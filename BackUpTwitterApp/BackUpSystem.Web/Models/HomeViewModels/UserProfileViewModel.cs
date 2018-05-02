using System;
using System.ComponentModel.DataAnnotations;

namespace BackUpSystem.Web.Models.HomeViewModels
{
    public class UserProfileViewModel
    {
        public string Id { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "Invalid UserName format!")]
        public string UserName { get; set; }

        [StringLength(40, MinimumLength = 2, ErrorMessage = "Invalid Name format!")]
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? BirthDate { get; set; }

        public int FollowedUsersCount { get; set; }

        public int DownloadedTweetsCount { get; set; }

        public int RetweetsCount { get; set; }

        public string UserImageUrl { get; set; }
    }
}
