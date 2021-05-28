using License.DataAccess.Infrastructure;
using License.Models.Models;
using License.Service.Logic.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace License.Service.Logic.Implementation
{
    public class SubcategoryLogic : ISubcategoryLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public SubcategoryLogic (IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Block(Guid subcategoryId)
        {
            var subcategory = _unitOfWork.SubcategoryRepository.GetById(subcategoryId);

            if (subcategory == null)
            {
                return;
            }

            subcategory.IsBlocked = true;
            _unitOfWork.Complete();
        }

        public IEnumerable<SubcategoryModel> Get()
        {
            return _unitOfWork.SubcategoryRepository.Get();
        }

        public IEnumerable<SubcategoryModel> Get(Guid categoryId)
        {
            return _unitOfWork.SubcategoryRepository.Get(categoryId);
        }

        public SubcategoryModel GetById(Guid subcategoryId)
        {
            return _unitOfWork.SubcategoryRepository.GetById(subcategoryId);
        }

        public void Post(Guid categoryId, string subcategoryName, string subcategoryDescription)
        {
            var subcategory = new SubcategoryModel
            {
                Id = Guid.NewGuid(),
                CategoryId = categoryId,
                Name = subcategoryName,
                Description = subcategoryDescription
            };

            _unitOfWork.SubcategoryRepository.Add(subcategory);
            _unitOfWork.Complete();
        }

        public void Unblock(Guid subcategoryId)
        {
            var subcategory = _unitOfWork.SubcategoryRepository.GetById(subcategoryId);

            if (subcategory == null)
            {
                return;
            }

            subcategory.IsBlocked = false;
            _unitOfWork.Complete();
        }

        public void Update(Guid subcategoryId, string subcategoryName, string subcategoryDescription)
        {
            var subcategory = _unitOfWork.SubcategoryRepository.GetById(subcategoryId);

            if (subcategory == null)
            {
                return;
            }

            subcategory.Name = subcategoryName;
            subcategory.Description = subcategoryDescription;

            _unitOfWork.Complete();
        }
    }
}
