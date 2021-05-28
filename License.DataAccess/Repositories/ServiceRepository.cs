using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using License.DataAccess.Infrastructure;
using License.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace License.DataAccess.Repositories
{
    public class ServiceRepository : BaseRepository<ServiceModel>, IServiceRepository
    {
        public ServiceRepository(LicenseDbContext dbContext) : base(dbContext)
        {
        }

        public ServiceModel Get(Guid id)
        {
            return _dbContext.Services.Include(s => s.Subcategory)
                .ThenInclude(s => s.Category)
                .FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<ServiceModel> Get(UserModel user)
        {
            return _dbContext.Services.Where(s => s.UserId == user.Id).AsEnumerable();
        }

        public IEnumerable<ServiceModel> Get()
        {
            return _dbContext.Services.Include(s => s.User).AsEnumerable();
        }

        public IEnumerable<ServiceModel> GetServicesForCategory(Guid categoryId)
        {
            var subcategoriesIds = _dbContext.Subcategories.Where(sc => sc.CategoryId == categoryId)
                .Select(sc => sc.Id)
                .AsEnumerable();
            return _dbContext.Services.Where(s => subcategoriesIds.Contains(s.SubcategoryId))
                .Include(s => s.User)
                .AsEnumerable();
        }

        public IEnumerable<ServiceModel> GetServicesForSubcategory(Guid subcategoryId)
        {
            return _dbContext.Services.Where(s => s.SubcategoryId == subcategoryId)
                .Include(s => s.User)
                .AsEnumerable();
        }
    }
}
