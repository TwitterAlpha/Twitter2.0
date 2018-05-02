using AutoMapper;
using BackUpSystem.Data.Models;
using BackUpSystem.DTO;
using BackUpSystem.DTO.ApiDtos;
using BackUpSystem.Web.Models.HomeViewModels;
using System.Linq;

namespace BackUpSystem.Web.Properties
{
    public class MappingSettings : Profile
    {
        public MappingSettings()
        {
            this.CreateMap<UserDto, User>(MemberList.Source);
            this.CreateMap<TwitterAccountApiDto, TwitterAccount>(MemberList.Source);
            this.CreateMap<TweetDto, Tweet>(MemberList.Source);
            this.CreateMap<TweetApiDto, Tweet>(MemberList.Source);
            this.CreateMap<TweetViewModel, TweetApiDto>(MemberList.Source);
            this.CreateMap<TwitterAccountViewModel, TwitterAccountApiDto>(MemberList.Source);

            this.CreateMap<User, UserDto>()
                .ForMember(x => x.FollowedUsersCount, options =>
                options.MapFrom(x => x.TwitterAccounts.ToList().Where(ta => !ta.IsDeleted).Count()))
                .ForMember(x => x.DownloadedTweetsCount, options => 
                options.MapFrom(x => x.FavoriteTweets.ToList().Where(ft => !ft.IsDeleted).Count()));

        }

        //Custom mappings to be added
        //Example:
        //this.CreateMap<PostDto, PostViewModel>()
        //           .ForMember(x => x.Author, options => options.MapFrom(x => x.Author.Email));

        //    this.CreateMap<CommentDto, CommentViewModel>()
        //           .ForMember(x => x.Author, options => options.MapFrom(x => x.Author.Email));

        //    this.CreateMap<PostViewModel, PostDto>(MemberList.Source);
        //    this.CreateMap<PostDto, Post>(MemberList.Source);

    }
}
