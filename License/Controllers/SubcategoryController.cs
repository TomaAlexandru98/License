using License.Service.Logic.Infrastructure;
using License.Service.Logic.ViewModels.Subcategories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace License.Service.Controllers
{
    public class SubcategoryController : Controller
    {
        private readonly ISubcategoryLogic _subcategoryLogic;
        private readonly ICategoryLogic _categoryLogic;

        public SubcategoryController(ISubcategoryLogic subcategoryLogic, ICategoryLogic categoryLogic)
        {
            _subcategoryLogic = subcategoryLogic;
            _categoryLogic = categoryLogic;
        }

        [HttpGet]
        public IActionResult Get(Guid categoryId)
        {
            var viewModel = new SubcategoriesViewModel
            {
                Subcategories = _subcategoryLogic.Get(categoryId),
                Category = _categoryLogic.Get(categoryId)
            };

            return View(viewModel);
        }

        [HttpGet]
        public JsonResult GetData(Guid categoryId)
        {
            var subcategories = _subcategoryLogic.Get(categoryId).Select(s => new { s.Id, s.Name });
            return Json(subcategories);
        }

        [HttpPost]
        public IActionResult Post(CreateSubcategoryViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Get", new { categoryId = viewModel.CategoryId });
            }

            _subcategoryLogic.Post(viewModel.CategoryId, viewModel.SubcategoryName, viewModel.SubcategoryDescription);
            return RedirectToAction("Get", new { categoryId = viewModel.CategoryId });
        }

        [HttpGet]
        public IActionResult Edit(Guid subcategoryId, Guid categoryId)
        {
            var subcategory = _subcategoryLogic.GetById(subcategoryId);
            var category = _categoryLogic.Get(categoryId);

            var viewModel = new CreateSubcategoryViewModel
            {
                SubcategoryId = subcategory.Id,
                SubcategoryName = subcategory.Name,
                SubcategoryDescription = subcategory.Description,
                CategoryId = category.Id,
                CategoryName = category.Name
            };

            return PartialView("_Edit", viewModel);
        }

        [HttpPost]
        public IActionResult Edit(CreateSubcategoryViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Get", new { categoryId = viewModel.CategoryId });
            }

            _subcategoryLogic.Update(viewModel.SubcategoryId, viewModel.SubcategoryName, viewModel.SubcategoryDescription);
            return RedirectToAction("Get", new { categoryId = viewModel.CategoryId });
        }

        public IActionResult Block(Guid subcategoryId, Guid categoryId)
        {
            _subcategoryLogic.Block(subcategoryId);
            return RedirectToAction("Get", new { categoryId = categoryId });
        }

        public IActionResult Unblock(Guid subcategoryId, Guid categoryId)
        {
            _subcategoryLogic.Unblock(subcategoryId);
            return RedirectToAction("Get", new { categoryId = categoryId });
        }
    }
}
