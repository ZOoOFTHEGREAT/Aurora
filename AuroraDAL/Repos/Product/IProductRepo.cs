using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public interface IProductRepo:IGenericRepo<Product>
{
    List<Product>? GetProductByCategory(int id);
    List<Product>? GetProductByPrice(int price1, int price2);
    List<Product>? GetProductByName(string productname);
    List<Product>? GetProductByDiscount();
    new List<Product> GetAll();
    new Product? GetById(int id);
}
