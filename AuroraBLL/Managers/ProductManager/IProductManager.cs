using AuroraBLL.Dtos.OrderDtos;
using AuroraBLL.Dtos.ProductDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Managers.ProductManager
{
    public interface IProductManager
    {
        bool Add(ProductAddDto product);
        bool Update(ProductUpdateDto product);
        bool Delete(int productid);

        IEnumerable<ReadAllProductsDto> GetAllProducts();
        ReadProductByIdDto? GetProductById(int productid);
        IEnumerable<ReadProductsByCategoryIdDto> GetProductsByCategoryId(int categoryid);
        IEnumerable<ReadProductsByDiscountDto> GetProductsByDiscount();
        IEnumerable<ReadProductsByNameDto> GetProductsByName(string productname);
        IEnumerable<ReadProductsByPriceDto> GetProductsByPrice(int minimumprice,int maximumprice );

    }
}
