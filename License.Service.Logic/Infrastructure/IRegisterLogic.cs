using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using License.Models.Models;
using License.Service.Logic.DTOs;
using License.Service.Logic.ViewModels.Register;
using Microsoft.AspNetCore.Identity;

namespace License.Service.Logic.Infrastructure
{
    public interface IRegisterLogic
    {
        void Register(string userId, string firstName, string lastName, string email, string phoneNo);
    }
}
