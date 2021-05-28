using System;
using System.Collections.Generic;
using System.Text;
using License.Models.Models;
using License.Models.Poco;

namespace License.DataAccess.Infrastructure
{
    public interface IServiceRepository : IBaseRepository<ServiceModel>
    {
        ServiceModel Get(Guid id);
        IEnumerable<ServiceModel> Get(UserModel user);
        IEnumerable<ServiceModel> Get();
        IEnumerable<ServiceModel> GetServicesForCategory(Guid categoryId);
        IEnumerable<ServiceModel> GetServicesForSubcategory(Guid subcategoryId);
    }
}
