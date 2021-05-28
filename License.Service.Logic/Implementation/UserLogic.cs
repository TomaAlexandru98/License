using System;
using System.Collections.Generic;
using System.Text;
using License.DataAccess.Infrastructure;
using License.Models.Models;
using License.Models.Poco;
using License.Service.Logic.Infrastructure;

namespace License.Service.Logic.Implementation
{
    public class UserLogic : IUserLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public UserLogic(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public UserModel GetUser(string userId)
        {
            var user = _userRepository.GetUser(userId);
            return user;
        }
    }
}
