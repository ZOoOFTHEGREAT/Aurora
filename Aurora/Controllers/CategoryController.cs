using AuroraBLL.Dtos.CategoryDtos;
using AuroraBLL.Managers.CategoryManager;
using AuroraDAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuroraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        #region Inject 

        private readonly ICategoryManager categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            this.categoryManager = categoryManager;
        }

        #endregion

        #region Get All Categories
        [HttpGet]
        [Route("Categories")]

        public ActionResult<IEnumerable<ReadCategoriesDto>> GetAllCategories()
        {
            IEnumerable<ReadCategoriesDto> categories= categoryManager.GetCategories();
            return Ok(categories);
        }
        #endregion

        #region Get Category Details By ID
        [HttpGet]
        [Route("{CategoryId}")]
        public ActionResult<ReadCategoryDetailsDto> GetCategory(int CategoryId)
        {
            ReadCategoryDetailsDto? category = categoryManager.GetCategoryDetails(CategoryId);
            if (category == null) { return NotFound(); }
            return Ok(category);
        }
        #endregion

        #region Add Category
        [HttpPost]
        [Route("AddCategory")]

        public ActionResult Add(AddCategoryDto categoryToAdd)
        {
            int isAdded = categoryManager.AddCategory(categoryToAdd);
            return isAdded>0 ? Ok(isAdded) : BadRequest(isAdded);
        }
        #endregion

        #region Update Category
        [HttpPut]
        [Route("UpdateCategory")]

        public ActionResult Edit(UpdateCategoryDto categoryToUpdate)
        {
            bool isEdited = categoryManager.UpdateCategory(categoryToUpdate);

            return isEdited ? Accepted() : BadRequest();
        }
        #endregion

        #region Delete Category
        [HttpDelete]
        [Route("{CategoryToDeleteId}")]

        public ActionResult Delete(int CategoryToDeleteId)
        {
            bool isDeleted = categoryManager.DeleteCategory(CategoryToDeleteId);

            return isDeleted ? Accepted() : BadRequest();
        }
        #endregion

        #region Get All Categories Names
        [HttpGet]
        [Route("CategoriesNames")]

        public ActionResult<IEnumerable<ReadCategoryNamesOnlyDto>> GetAllCategoriesNames()
        {
            IEnumerable<ReadCategoryNamesOnlyDto> categoriesNames = categoryManager.GetCategoriesNames();
            return Ok(categoriesNames);
        }

        #endregion

    }
}
