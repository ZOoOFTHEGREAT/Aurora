using AuroraBLL.Dtos.CategoryDtos;
using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Managers.CategoryManager
{
    public interface ICategoryManager
    {
        int AddCategory(AddCategoryDto category);
        IEnumerable<ReadCategoriesDto> GetCategories();
        ReadCategoryDetailsDto? GetCategoryDetails(int CategoryId);
        bool UpdateCategory(UpdateCategoryDto category);

    }
}
