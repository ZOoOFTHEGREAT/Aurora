using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class ProductRepo:GenericRepo<Product>, IProductRepo
{
    #region Inject
    private readonly AppDbContext appDbContext;

    public ProductRepo(AppDbContext appDbContext):base(appDbContext)
    {
        this.appDbContext = appDbContext;

    }
    #endregion

    #region Get Product By Category
    public List<Product>? GetProductByCategory(int CategoryId)
    {
        return appDbContext.Products.Include(Product => Product.Images).Where(x => x.CategoryId == CategoryId).ToList();
    }
    #endregion

    #region Get Product By Discount
    public List<Product>? GetProductByDiscount()
    {
        return appDbContext.Products.Include(Product => Product.Images).Where(x => x.DiscountPercent != 0).ToList();
    }
    #endregion

    #region Get Product By Name 
    public List<Product>? GetProductByName(string productname)
    {
        return appDbContext.Products.Include(Product => Product.Images).Where(x => x.Name == productname).ToList();
    }
    #endregion

    #region Get Product By Price 
    public List<Product>? GetProductByPrice(int price1, int price2)
    {
        return appDbContext.Products.Include(Product => Product.Images).Where(x => x.Price <= price1 && x.Price >= price2).ToList();
    }
    #endregion

    public new List<Product> GetAll()
    {
        return appDbContext.Set<Product>().
           Include(Product => Product.Images).ToList();
    }
    public new Product? GetById(int id)
    {
        return appDbContext.Set<Product>().
            Include(Product => Product.Images).
            FirstOrDefault(Product => Product.Id == id);
    }
}
