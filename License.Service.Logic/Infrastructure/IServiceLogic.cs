using System;
using System.Collections.Generic;
using System.Text;
using License.Models.Models;
using License.Service.Logic.ViewModels.Services;

namespace License.Service.Logic.Infrastructure
{
    public interface IServiceLogic
    {
        ServiceModel Get(Guid serviceId);
        IEnumerable<ServiceModel> Get();
        IEnumerable<ServiceModel> GetUserServices(UserModel user);
        void Post(CreateProjectViewModel viewModel, Guid userId, string imageDirectory);
        void Remove(Guid serviceId);
        IEnumerable<ServiceModel> Filter(Guid categoryId, Guid subcategoryId);
        string GetDeliveryTimeTranslation(DeliveryTime deliveryTime);
    }
}
