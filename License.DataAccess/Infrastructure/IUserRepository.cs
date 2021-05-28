using System;
using System.Collections.Generic;
using System.Text;
using License.Models.Models;

namespace License.DataAccess.Infrastructure
{
    public interface IUserRepository : IBaseRepository<UserModel>
    {
        UserModel GetUser(string userId);
    }
}
