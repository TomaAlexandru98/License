using System;
using System.Collections.Generic;
using System.Text;
using License.Models.Models;

namespace License.Service.Logic.Infrastructure
{
    public interface IUserLogic
    {
        UserModel GetUser(string userId);
    }
}
