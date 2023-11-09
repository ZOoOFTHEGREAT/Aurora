using AuroraBLL.Dtos.CategoryDtos;
using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Managers.CategoryManager
{
    public class CategoryManager : ICategoryManager
    {

        #region Inject Of UnitWork
        
        private readonly UnitOfWork unitOfWork;

        public CategoryManager(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #endregion
 
        #region Get Categories Names and IDs

        public IEnumerable<ReadCategoriesDto> GetCategories()
        {
            IEnumerable<ReadCategoriesDto> Categories = unitOfWork.CategoryRepo.GetAll().Select(x=>new ReadCategoriesDto
            {
                Id = x.Id,
                Name = x.Name,
            });
            return Categories;
                
        }
        #endregion

        #region Get Category Details
        public ReadCategoryDetailsDto? GetCategoryDetails(int CategoryId)
        {
            Category? Category = unitOfWork.CategoryRepo.GetById(CategoryId);
            if (Category == null)
                return null;
            return new ReadCategoryDetailsDto
            {
                Id = Category.Id,
                Name = Category.Name,
                Description = Category.Description,
            };
        }
        #endregion

        #region Add Category
        public int AddCategory(AddCategoryDto category)
        {
            Category Category=new Category()
            {
                Name = category.Name,
                Description = category.Description,
            };
            unitOfWork.CategoryRepo.Add(Category);
            return unitOfWork.SaveChanges();
        }
        #endregion

        #region Update Category

        public bool UpdateCategory(UpdateCategoryDto category)
        {
            Category? Category = unitOfWork.CategoryRepo.GetById(category.Id);

            if (Category == null) 
                return false;

            Category.Id = category.Id;
            Category.Name = category.Name;
            Category.Description = category.Description;
            //Separation of concerns : tracking but also calling update
            unitOfWork.CategoryRepo.Update(Category);
            return unitOfWork.SaveChanges() > 0;
            
        }

        #endregion

    }
}
