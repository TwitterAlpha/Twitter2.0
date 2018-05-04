using BackUpSystem.Data.Models;
using BackUpSystem.Date.Repositories.Contracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackUpSystem.Data.Repositories.Contracts
{
    /// <summary>
    /// Represent a <see cref="IUserRepository"/> interface. Heir of <see cref="IRepository{User}"/>
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        Task<string> GetAdminRoleId();

        Task<IEnumerable<IdentityUserRole<string>>> GetAllRoles();
        // <summary>
        /// Finds a user given username.
        /// </summary>
        /// <param name="username">Username of the user.</param>
        /// <returns>The user with the provided username if exist. Otherwise <see cref="null"/>.</returns>
        Task<User> GetUserByUsername(string username);

        /// <summary>
        /// Provide collection of following Twitter Accounts.
        /// </summary>
        /// <param name="id">User's Id</param>
        /// <returns>A collection of all Twitter Account followed by the user.</returns>
        Task<IEnumerable<TwitterAccount>> GetAllFavoriteTwitterAccounts(string id);

        /// <summary>
        /// Provide collection of downloaded tweets.
        /// </summary>
        /// <param name="id">User's Id</param>
        /// <returns>A collection of all downloaded tweets by the user.</returns>
        Task<IEnumerable<Tweet>> GetAllDownloadedTweets(string id);

        /// <summary>
        /// Adds a Twitter Account to User's favorites
        /// </summary>
        /// <param name="userId">User object/param>
        /// <param name="twitterAccountId">TwitterAccount object</param>
        /// <returns>A collection of all downloaded TwitterAccounts by the user.</returns>
        Task<bool> TwitterAccountAddedToUser(User user, TwitterAccount twitterAccount);

        /// <summary>
        /// Downloads a tweet to User's Downloaded Tweets
        /// </summary>
        /// <param name="userId">User object</param>
        /// <param name="tweet">Tweet object</param>
        /// <returns>A collection of all downloaded tweets by the user.</returns>
        Task<bool> TweetDownloaded(User user, Tweet tweet);

        /// <summary>
        /// Deletes the user from all other tables;
        /// </summary>
        /// <param name="userId">User's Id</param>
        void DeleteUserFromOtherTables(string userId);

        /// <summary>
        /// Updates user's Name;
        /// </summary>
        /// <param name="id">User's Id</param>
        /// <param name="name">User's name</param>
        /// <returns>A collection of all downloaded tweets by the user.</returns>
        Task UpdateName(string id, string name);

        /// <summary>
        /// Updates user's Birth date;
        /// </summary>
        /// <param name="id">User's Id</param>
        /// <param name="birthDate">User's Birth date</param>
        /// <returns>A collection of all downloaded tweets by the user.</returns>
        void UpdateBirthDate(string id, DateTime? birthDate);

        /// <summary>
        /// Updates user's Image url;
        /// </summary>
        /// <param name="id">User's Id</param>
        /// <param name="imageUrl">User's Image url</param>
        /// <returns>A collection of all downloaded tweets by the user.</returns>
        void UpdateImageUrl(string id, string imageUrl);

        //void IncludeFavoriteTwitterAccounts();

        //void IncludeFavoriteTweets();
    }
}
