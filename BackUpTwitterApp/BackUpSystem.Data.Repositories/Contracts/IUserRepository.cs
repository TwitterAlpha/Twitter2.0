using BackUpSystem.Data.Models;
using BackUpSystem.Date.Repositories.Contracts;
using System.Collections.Generic;

namespace BackUpSystem.Data.Repositories.Contracts
{
    /// <summary>
    /// Represent a <see cref="IUserRepository"/> interface. Heir of <see cref="IRepository{User}"/>
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        // <summary>
        /// Finds a user given username.
        /// </summary>
        /// <param name="username">Username of the user.</param>
        /// <returns>The user with the provided username if exist. Otherwise <see cref="null"/>.</returns>
        User GetUserByUsername(string username);

        /// <summary>
        /// Provide collection of following Twitter Accounts.
        /// </summary>
        /// <param name="id">User's Id</param>
        /// <returns>A collection of all Twitter Account followed by the user.</returns>
        IEnumerable<UserTwitterAccount> GetAllFavoriteTwitterAccounts(string id);

        /// <summary>
        /// Provide collection of downloaded tweets.
        /// </summary>
        /// <param name="id">User's Id</param>
        /// <returns>A collection of all downloaded tweets by the user.</returns>
        IEnumerable<UserTweet> GetAllDownloadedTweets(string id);
    }
}
