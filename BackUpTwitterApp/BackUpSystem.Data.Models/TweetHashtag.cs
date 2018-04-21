namespace BackUpSystem.Data.Models
{
    public class TweetHashtag
    {
        public string TweetId { get; set; }
        public Tweet Tweet { get; set; }

        public string HashtagId { get; set; }
        public Hashtag Hashtag { get; set; }
    }
}
