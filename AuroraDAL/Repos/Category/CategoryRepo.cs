using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class CategoryRepo : GenericRepo<Category>, ICategoryRepo
{
    #region Inject
    private readonly AppDbContext appDbContext;

    public CategoryRepo(AppDbContext appDbContext) : base(appDbContext)
    {
        this.appDbContext = appDbContext;
    }
    #endregion
    public new List<Category> GetAll()
    {
        return appDbContext.Set<Category>().Include(Category => Category.Products).ThenInclude(product => product.Images).ToList();
    }
    public new Category? GetById(int id)
    {
        return appDbContext.Set<Category>().Include(Category => Category.Products).ThenInclude(product => product.Images).FirstOrDefault(Category => Category.Id == id);
    }

}
