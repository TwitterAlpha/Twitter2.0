namespace BackUpSystem.Services.Auth.Contracts
{
    public interface IFacebookCredentials
    {
        /// <summary>
        /// Stores AppId parameter, required for authorization
        /// </summary>
        string AppId { get; }

        /// <summary>
        /// Stores AppSecret parameter, required for authorization
        /// </summary>
        string AppSecret { get; }
    }
}
