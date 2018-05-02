using System;

namespace BackUpSystem.DTO
{
    public class TweetDto
    {
        public string Id { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string Text { get; set; }

        public string TweetAuthor { get; set; }

        public int LikesCount { get; set; }

        public int RetweetCount { get; set; }

        public string MediaUrl { get; set; }

        public string TweetUrl { get; set; }
    }
}
