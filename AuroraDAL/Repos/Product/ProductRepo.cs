using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class ProductRepo:GenericRepo<Product>, IProductRepo
{
    private readonly AppDbContext appDbContext;

    public ProductRepo(AppDbContext appDbContext):base(appDbContext)
    {
        this.appDbContext = appDbContext;

    }

    public List<Product>? GetProductByCategory(int id)
    {
        return appDbContext.Products.Where(x => x.CategoryId == id).ToList();
    }

    public List<Product>? GetProductByDiscount()
    {
        return appDbContext.Products.Where(x => x.DiscountPercent != 0).ToList();
    }

    public List<Product>? GetProductByName(string productname)
    {
        return appDbContext.Products.Where(x => x.Name == productname).ToList();
    }

    public List<Product>? GetProductByPrice(int price1, int price2)
    {
        return appDbContext.Products.Where(x => x.Price <= price1 && x.Price >= price2).ToList();
    }
    }
}
