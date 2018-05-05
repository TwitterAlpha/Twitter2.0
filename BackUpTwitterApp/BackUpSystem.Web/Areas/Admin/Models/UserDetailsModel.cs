using BackUpSystem.DTO;
using BackUpSystem.DTO.ApiDtos;
using BackUpSystem.Services.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackUpSystem.Web.Areas.Admin.Models
{
    public class UserDetailsModel
    {
        public UserDetailsModel()
        {
            this.User = new UserDto();
            this.Tweets = new HashSet<TweetApiDto>();
            this.TwitterAccounts = new HashSet<TwitterAccountDto>();
        }

        public UserDto User { get; set; }
        public ICollection<TweetApiDto> Tweets { get; set; }
        public IEnumerable<TwitterAccountDto> TwitterAccounts { get; set; }

    }

    
}
