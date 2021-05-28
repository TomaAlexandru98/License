using System;
using System.Collections.Generic;
using System.Text;
using License.DataAccess.Infrastructure;
using License.Models.Models;
using License.Service.Logic.Infrastructure;
using License.Service.Logic.ViewModels.Category;

namespace License.Service.Logic.Implementation
{
    public class CategoryLogic : ICategoryLogic
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _categoryRepository = unitOfWork.CategoryRepository;
        }

        public void Block(Guid categoryId)
        {
            var category = _unitOfWork.CategoryRepository.Get(categoryId);

            if (category == null)
            {
                return;
            }

            category.IsBlocked = true;
            _unitOfWork.Complete();
        }

        public IEnumerable<CategoryModel> Get()
        {
            return _categoryRepository.Get();
        }

        public CategoryModel Get(Guid categoryId)
        {
            return _categoryRepository.Get(categoryId);
        }

        public CategoryModel GetCategoryFromSubcategoryId(Guid subcategoryId)
        {
            return _categoryRepository.GetCategoryFromSubcategoryId(subcategoryId);
        }

        public void Post(string name, string description)
        {
            var category = new CategoryModel
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description
            };

            _categoryRepository.Add(category);
            _unitOfWork.Complete();
        }

        public void Unblock(Guid categoryId)
        {
            var category = _unitOfWork.CategoryRepository.Get(categoryId);

            if (category == null)
            {
                return;
            }

            category.IsBlocked = false;
            _unitOfWork.Complete();
        }

        public void Update(Guid id, string name, string description)
        {
            var category = _categoryRepository.Get(id);

            if (category != null)
            {
                category.Name = name;
                category.Description = description;
            }

            _unitOfWork.Complete();
        }
    }
}
