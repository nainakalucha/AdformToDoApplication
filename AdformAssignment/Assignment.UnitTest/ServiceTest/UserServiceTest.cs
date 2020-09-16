using Assignment.Api.Core;
using Assignment.Contract.Core;
using Assignment.DAL.Core;
using AutoMapper;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Assignment.UnitTest
{
    /// <summary>
    /// 
    /// </summary>
    public class UserServiceTest
    {
        /// <summary>
        /// The repo
        /// </summary>
        private Mock<IGenericRepository> _repo;
        /// <summary>
        /// The mapper
        /// </summary>
        private Mock<IMapper> _mapper;
        /// <summary>
        /// The user service
        /// </summary>
        private UserService userService;

        /// <summary>
        /// Setups this instance.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _repo = new Mock<IGenericRepository>();
            _mapper = new Mock<IMapper>();
            userService = new UserService(_repo.Object, _mapper.Object);
        }

        /// <summary>
        /// Authenticates the user invalid credentials.
        /// </summary>
        [Test]
        public void AuthenticateUser_InvalidCredentials()
        {
            string username = string.Empty;
            string password = string.Empty;
            _repo.Setup(p => p.GetWithCondition<UserEntity>(x => x.Username == username && x.Password == password)).Returns(new List<UserEntity>());
            var returnObj = userService.AuthenticateUser(string.Empty, string.Empty);
            Assert.IsTrue(returnObj == null);
        }

        /// <summary>
        /// Authenticates the user valid credentials.
        /// </summary>
        [Test]
        public void AuthenticateUser_ValidCredentials()
        {            
            string username = "sunaina";
            string password = "password";
            List<UserEntity> userList = new List<UserEntity>();
            userList.Add(new UserEntity { Id = 1, Username = "sunaina", Password = "password" });
            _repo.Setup(p => p.GetWithCondition<UserEntity>(x => x.Username == username && x.Password == password)).Returns(userList);
            var returnObj = userService.AuthenticateUser(username, password);
            Assert.IsTrue(returnObj != null);
        }

    }
}







