using System;

namespace BackUpSystem.DTO
{
    public class TwitterAccountDto
    {
        public string UserName { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int FollowersCount { get; set; }

        public int FollowingCount { get; set; }

        public int LikesCount { get; set; }

        public int TweetsCount { get; set; }

        public DateTime? JoinedDate { get; set; }

        public string WebsiteUrl { get; set; }

        public string ImageUrl { get; set; }
    }
}
