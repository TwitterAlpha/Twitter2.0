using System.Collections.Generic;

namespace BackUpSystem.Web.Models.HomeViewModels
{
    public class TimelineViewModel
    {
        public IEnumerable<TweetViewModel> Tweets { get; set; }

        public TwitterAccountViewModel TwiitterAccountInfo { get; set; }
    }
}
