using AuroraBLL.Dtos.CartItemDtos;
using AuroraBLL.Dtos.CategoryDtos;
using AuroraBLL.Dtos.ImageDtos;
using AuroraBLL.Dtos.ProductDtos;
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
        
        private readonly IUnitOfWork unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        #endregion
 
        #region Get Categories

        public IEnumerable<ReadCategoriesDto> GetCategories()
        {
            IEnumerable<ReadCategoriesDto> Categories = unitOfWork.CategoryRepo.GetAll().Select(Category => new ReadCategoriesDto
            {
                Name = Category.Name,
                Description = Category.Description,
                Products = Category.Products.Select(product => new ReadProductByIdDto
                {
                    Name = product.Name ,
                    Price = product.Price ,
                    Quantity = product.Quantity ,
                     DiscountPercent = product.DiscountPercent, 
                     Description = product.Description ,
                     CategoryId = product.CategoryId ,
                    Images = product.Images.Select(image => new ReadImageDto
                    {
                        ImageUrl = image.ImageUrl,
                    }).ToList(),
                }).ToList(),
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
                Name = Category.Name,
                Description = Category.Description,
                Products = Category.Products.Select(product => new ReadProductByIdDto
                {
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = product.Quantity,
                    DiscountPercent = product.DiscountPercent,
                    Description = product.Description,
                    CategoryId = product.CategoryId,
                    Images = product.Images.Select(image => new ReadImageDto 
                    {
                        ImageUrl = image.ImageUrl,
                    }).ToList(),
                }).ToList(),
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

        #region Delete Category
        public bool DeleteCategory(int id)
        {
            Category? categorytobedelted = unitOfWork.CategoryRepo.GetById(id);
            if (categorytobedelted == null) { return false; }
            unitOfWork.CategoryRepo.Delete(categorytobedelted);
            unitOfWork.SaveChanges();
            return true;
        }
        #endregion

        #region Get Categories Names Only

        public IEnumerable<ReadCategoryNamesOnlyDto> GetCategoriesNames()
        {
            IEnumerable<ReadCategoryNamesOnlyDto> Categories = unitOfWork.CategoryRepo.GetAll().Select(x => new ReadCategoryNamesOnlyDto
            {
                Name = x.Name,
            });
            return Categories;

        }
        #endregion

    }
}
