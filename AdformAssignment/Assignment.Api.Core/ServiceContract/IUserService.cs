using Assignment.Contract.Core;

namespace Assignment.Api.Core
{
    /// <summary>
    /// 
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Authenticates the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        UserDTO AuthenticateUser(string username, string password);
    }
}
