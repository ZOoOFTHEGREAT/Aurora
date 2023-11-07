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
        return appDbContext.Products.Where(x => x.CategoryId == CategoryId).ToList();
    }
    #endregion

    #region Get Product By Discount
    public List<Product>? GetProductByDiscount()
    {
        return appDbContext.Products.Where(x => x.DiscountPercent != 0).ToList();
    }
    #endregion

    #region Get Product By Name 
    public List<Product>? GetProductByName(string productname)
    {
        return appDbContext.Products.Where(x => x.Name == productname).ToList();
    }
    #endregion

    #region Get Product By Price 
    public List<Product>? GetProductByPrice(int price1, int price2)
    {
        return appDbContext.Products.Where(x => x.Price <= price1 && x.Price >= price2).ToList();
    }
    #endregion

}
