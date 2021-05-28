using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using License.Service.Logic.Infrastructure;
using License.Service.Logic.ViewModels.Category;

namespace License.Service.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryLogic _categoryLogic;

        public CategoryController(ICategoryLogic categoryLogic)
        {
            _categoryLogic = categoryLogic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var viewModel = new CategoriesViewModel
            {
                Categories = _categoryLogic.Get()
            };
            
            return View(viewModel);
        }

        [HttpGet]
        public JsonResult GetData()
        {
            var categories = _categoryLogic.Get().Select(x => new { x.Id, x.Name });
            return Json(categories);
        }

        [HttpPost]
        public IActionResult Post(CreateCategoryViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Get");
            }

            _categoryLogic.Post(viewModel.Name, viewModel.Description);
            return RedirectToAction("Get");
        }

        [HttpGet]
        public IActionResult Edit(Guid categoryId)
        {
            var category = _categoryLogic.Get(categoryId);

            var viewModel = new CreateCategoryViewModel
            {
                CategoryId = category.Id,
                Name = category.Name,
                Description = category.Description
            };
            
            return PartialView("_Edit", viewModel);
        }

        [HttpPost]
        public IActionResult Edit(CreateCategoryViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Get");
            }

            _categoryLogic.Update(viewModel.CategoryId, viewModel.Name, viewModel.Description);
            return RedirectToAction("Get");
        }

        public IActionResult Block(Guid categoryId)
        {
            _categoryLogic.Block(categoryId);
            return RedirectToAction("Get");
        }

        public IActionResult Unblock(Guid categoryId)
        {
            _categoryLogic.Unblock(categoryId);
            return RedirectToAction("Get");
        }
    }
}
