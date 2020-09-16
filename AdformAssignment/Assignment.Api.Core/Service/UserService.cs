using Assignment.Contract.Core;
using Assignment.Dal;
using Assignment.DAL.Core;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Api.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Assignment.Api.Core.IUserService" />
    public class UserService : IUserService
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly IGenericRepository _repo;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserService"/> class.
        /// </summary>
        /// <param name="repo">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        public UserService(IGenericRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Authenticates the user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public UserDTO AuthenticateUser(string username, string password)
        {
            var userEntity = _repo.GetWithCondition<UserEntity>(x => x.Username == username && x.Password == password).FirstOrDefault();
            var userDto =_mapper.Map<UserEntity, UserDTO>(userEntity);
            return userDto;
        }
    }

}
