using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using License.Models.Poco;
using License.Service.Logic.Infrastructure;
using License.Service.Logic.ViewModels.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using License.Service.Logic.Helpers;

namespace License.Service.Controllers
{
    public class ServiceController : Controller
    {
        private readonly IServiceLogic _serviceLogic;
        private readonly ICategoryLogic _categoryLogic;
        private readonly ISubcategoryLogic _subcategoryLogic;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserLogic _userLogic;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ServiceController(IServiceLogic serviceLogic,
            UserManager<IdentityUser> userManager,
            IUserLogic userLogic,
            IWebHostEnvironment webHostEnvironment,
            ICategoryLogic categoryLogic,
            ISubcategoryLogic subcategoryLogic)
        {
            _serviceLogic = serviceLogic;
            _categoryLogic = categoryLogic;
            _userManager = userManager;
            _subcategoryLogic = subcategoryLogic;
            _userLogic = userLogic;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult GetAll(Guid categoryId, Guid subcategoryId)
        {
            try
            {
                var services = _serviceLogic.Filter(categoryId, subcategoryId);
                var viewModel = new ServicesViewModel
                {
                    Services = services,
                    NumberOfResult = services.Count(),
                    Categories = _categoryLogic.Get().OrderByDescending(c => c.Name)
                };

                var subcategory = _subcategoryLogic.GetById(subcategoryId);

                if (subcategory != null)
                {
                    viewModel.ShouldDisplayData = true;
                    viewModel.Title = subcategory.Name;
                    viewModel.Description = subcategory.Description;

                    var category = _categoryLogic.GetCategoryFromSubcategoryId(subcategoryId);
                    if (category != null)
                    {
                        viewModel.CategoryName = category.Name;
                        viewModel.CategoryId = category.Id;
                    }
                }
                else 
                {
                    var category = _categoryLogic.Get(categoryId);

                    if (category != null)
                    {
                        viewModel.ShouldDisplayData = true;
                        viewModel.Title = category.Name;
                        viewModel.Description = category.Description;
                        viewModel.CategoryName = category.Name;
                        viewModel.CategoryId = category.Id;
                    }
                }

                return View(viewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IActionResult Details(Guid id)
        {
            try
            {
                var service = _serviceLogic.Get(id);

                var viewModel = new DetailsProjectViewModel
                {
                    Id = service.Id,
                    CategoryName = service.Subcategory.Category.Name,
                    CategoryId = service.Subcategory.CategoryId,
                    SubcategoryName = service.Subcategory.Name,
                    SubcategoryId = service.SubcategoryId,
                    Preview = service.Preview,
                    Price = service.Price,
                    Description = service.Description,
                    DeliveryTime = _serviceLogic.GetDeliveryTimeTranslation(service.DeliveryTime),
                    Categories = _categoryLogic.Get(),
                    SellerEmail = "tomaalex955@yahoo.com"
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetUserServices()
        {
            try
            {
                var userId = _userManager.GetUserId(User);
                var user = _userLogic.GetUser(userId);

                var viewModel = new UserServicesViewModel
                {
                    Services = _serviceLogic.GetUserServices(user)
                };
                return View(viewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        
        [HttpPost]
        public IActionResult Post(CreateProjectViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return RedirectToAction("GetUserServices");
                }

                string imageDirectory = Path.Combine(_webHostEnvironment.WebRootPath, "ServiceImages");
                var userId = _userManager.GetUserId(User);
                var user = _userLogic.GetUser(userId);

                _serviceLogic.Post(viewModel, user.Id, imageDirectory);
                return RedirectToAction("GetUserServices");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetUserServiceDetails(Guid serviceId)
        {
            var viewModel = _serviceLogic.Get(serviceId);
            return View(viewModel);
        }

        public IActionResult Delete(Guid serviceId)
        {
            _serviceLogic.Remove(serviceId);
            return RedirectToAction("GetUserServices");
        }
    }
}
