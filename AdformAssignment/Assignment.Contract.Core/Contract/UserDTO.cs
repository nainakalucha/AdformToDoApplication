using System;

namespace Assignment.Contract.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Assignment.Contract.Core.BaseDTO" />
    public class UserDTO: BaseDTO
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Int64 Id { get; set; }
        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        public string Username { get; set; }
        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; set; }
    }
 }
