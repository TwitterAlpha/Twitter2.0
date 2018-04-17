namespace BackUpSystem.Data.Models
{
    public class UserTwitterAccount
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public string TwitterAccountId { get; set; }
        public TwitterAccount TwitterAccount { get; set; }
    }
}
