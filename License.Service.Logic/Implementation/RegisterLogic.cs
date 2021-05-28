using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using License.DataAccess.Infrastructure;
using License.Models.Models;
using License.Service.Logic.DTOs;
using License.Service.Logic.Infrastructure;
using License.Service.Logic.ViewModels.Register;
using License.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;

namespace License.Service.Logic.Implementation
{
    public class RegisterLogic : IRegisterLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public RegisterLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = unitOfWork.UserRepository;
        }

        public void Register(string userId, string firstName, string lastName, string email, string phoneNo)
        {
            {
                var user = new UserModel
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    PhoneNo = phoneNo
                };

                _userRepository.Add(user);
                _unitOfWork.Complete();
            }
        }
    }
}
