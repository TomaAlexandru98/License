using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using License.DataAccess.Infrastructure;
using License.Models.Models;

namespace License.DataAccess.Repositories
{
    public class UserRepository : BaseRepository<UserModel>, IUserRepository
    {
        public UserRepository(LicenseDbContext dbContext) : base(dbContext)
        {
        }

        public UserModel GetUser(string userId)
        {
            return _dbContext.Users.FirstOrDefault(u => u.UserId == userId);
        }
    }
}
