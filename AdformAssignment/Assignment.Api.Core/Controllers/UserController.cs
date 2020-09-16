using Assignment.Contract.Core;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace Assignment.Api.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiController]
    public class UserController : ControllerBase
    {
        /// <summary>
        /// The logger
        /// </summary>
        private Framework.Core.ILogger _logger;
        /// <summary>
        /// The user service
        /// </summary>
        private IUserService _userservice;

        /// <summary>
        /// Initializes a new instance of the <see cref="LabelController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="userService">The user service.</param>
        public UserController(Framework.Core.ILogger logger, IUserService userService)
        {
            _logger = logger;
            _userservice = userService;
        }

        /// <summary>
        /// Authenticates the user
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/User")]
        public ActionResult<UserDTO> AuthenticateUser(string username, string password)
        {           
            _logger.Info(() => "Authenticating user");
            var userdto = _userservice.AuthenticateUser(username, password);
            return StatusCode((int)HttpStatusCode.OK, userdto);
        }
    }
}
