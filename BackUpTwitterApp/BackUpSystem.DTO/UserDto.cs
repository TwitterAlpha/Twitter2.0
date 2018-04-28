using System;

namespace BackUpSystem.DTO
{
    public class UserDto
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public DateTime? JoinedDate { get; set; }

        public DateTime? BirthDate { get; set; }

        public int FollowedUsersCount { get; set; }

        public int DownloadedTweetsCount { get; set; }

        public int RetweetsCount { get; set; }

        public string UserImageUrl { get; set; }
    }
}
