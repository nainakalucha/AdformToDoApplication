using Assignment.Api.Core;
using Assignment.Contract.Core;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;

namespace Assignment.UnitTest
{
    /// <summary>
    /// 
    /// </summary>
    public class UserControllerTest
    {
        /// <summary>
        /// The user service
        /// </summary>
        private Mock<IUserService> _userService;
        /// <summary>
        /// The logger
        /// </summary>
        private Mock<Framework.Core.ILogger> _logger;
        /// <summary>
        /// The user controller
        /// </summary>
        private UserController userController;

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _userService = new Mock<IUserService>();
            _logger = new Mock<Framework.Core.ILogger>();
            userController = new UserController(_logger.Object, _userService.Object);
        }

        /// <summary>
        /// Authenticates the user invalid credentials.
        /// </summary>
        [Test]
        public void AuthenticateUser_InvalidCredentials()
        {
            _userService.Setup(p => p.AuthenticateUser(string.Empty, string.Empty)).Returns(new Contract.Core.UserDTO());
             var returnObj = userController.AuthenticateUser(string.Empty, string.Empty);
            var okResult = returnObj.Result as ObjectResult;
            Assert.IsTrue(okResult.Value == null);
        }

        /// <summary>
        /// Authenticates the user valid credentials.
        /// </summary>
        [Test]
        public void AuthenticateUser_ValidCredentials()
        {
            UserDTO dto = new UserDTO { Id = 1, Username = "sunaina", Password = "password" };
            string username = "sunaina";
            string password = "password";
            _userService.Setup(p => p.AuthenticateUser(username, password)).Returns(dto);
            var returnObj = userController.AuthenticateUser(username, password);
            var okResult = returnObj.Result as ObjectResult;
            Assert.IsTrue((UserDTO)okResult.Value != null);
        }

    }
}







