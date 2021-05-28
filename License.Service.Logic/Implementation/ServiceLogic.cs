using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using License.DataAccess.Infrastructure;
using License.Models.Models;
using License.Service.Logic.Infrastructure;
using License.Service.Logic.ViewModels.Services;
using Microsoft.AspNetCore.Http;

namespace License.Service.Logic.Implementation
{
    public class ServiceLogic : IServiceLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceRepository _serviceRepository;

        public ServiceLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _serviceRepository = unitOfWork.ServiceRepository;
        }

        public ServiceModel Get(Guid serviceId)
        {
            return _serviceRepository.Get(serviceId);
        }

        public IEnumerable<ServiceModel> Get()
        {
            return _serviceRepository.Get();
        }

        public void Post(CreateProjectViewModel viewModel, Guid userId, string imageDirectory)
        {
            string imageSource = viewModel.Image != null ? GetImagePath(imageDirectory, viewModel.Image) : null;
            var service = new ServiceModel
            {
                Id = Guid.NewGuid(),
                Title = viewModel.Title,
                Preview = viewModel.Preview,
                Description = viewModel.Description,
                Price = viewModel.Price,
                DeliveryTime = viewModel.DeliveryTime,
                SubcategoryId = viewModel.SubcategoryId,
                Image = imageSource,
                UserId = userId
            };

            _serviceRepository.Add(service);
            _unitOfWork.Complete();
        }

        public IEnumerable<ServiceModel> GetUserServices(UserModel user)
        {
            return user != null ? _serviceRepository.Get(user) : null;
        }

        public void Remove(Guid serviceId)
        {
            var service = _serviceRepository.Get(serviceId);

            if (service != null)
            {
                _serviceRepository.Remove(service);
                _unitOfWork.Complete();
            }
        }

        public IEnumerable<ServiceModel> Filter(Guid categoryId, Guid subcategoryId)
        {
            if (categoryId != Guid.Empty)
            {
                return _serviceRepository.GetServicesForCategory(categoryId);
            }

            if (subcategoryId != Guid.Empty)
            {
                return _serviceRepository.GetServicesForSubcategory(subcategoryId);
            }

            return _serviceRepository.Get();
        }

        public string GetDeliveryTimeTranslation(DeliveryTime deliveryTime)
        {
            if (deliveryTime == DeliveryTime.LessThanADay)
            {
                return "Less than a day";
            }

            if (deliveryTime == DeliveryTime.OneDay)
            {
                return "One day";
            }

            if (deliveryTime == DeliveryTime.ThreeDays)
            {
                return "Three days";
            }

            if (deliveryTime == DeliveryTime.SevenDays)
            {
                return "Seven days";
            }

            return string.Empty;
        }

        #region Private functions

        private string GetImagePath(string uploadDir, IFormFile image)
        {
            string fileName = null;
            fileName = Guid.NewGuid().ToString() + "-" + image.FileName;
            string filePath = Path.Combine(uploadDir, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                image.CopyTo(fileStream);
            }

            return fileName;
        }

        #endregion
    }
}
