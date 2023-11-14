using AuroraBLL.Dtos.CategoryDtos;
using AuroraBLL.Dtos.ImageDtos;
using AuroraBLL.Dtos.PaymentDetailDtos;
using AuroraBLL.Dtos.ProductDtos;
using AuroraBLL.Managers.CategoryManager;
using AuroraBLL.Managers.ImageManager;
using AuroraBLL.Managers.PaymentDetailManager;
using AuroraBLL.Managers.ProductManager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuroraAPI.Controllers.ProductController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region Inject 
        private readonly IProductManager productmanger;

        public ProductController(IProductManager productManager)
        {
            this.productmanger = productManager;
        }
        #endregion

        #region Add 
        [HttpPost]
        [Route("AddProduct")]

        public ActionResult Add(ProductAddDto ProductToAdd)
        {
            bool isAdded = productmanger.Add(ProductToAdd);
            return isAdded ? Accepted() : BadRequest();
        }
        #endregion

        #region Delete
        [HttpDelete]
        [Route("{ProductToDeleteId}")]

        public ActionResult Delete(int ProductToDeleteId)
        {
            bool isDeleted = productmanger.Delete(ProductToDeleteId);

            return isDeleted ? Accepted() : BadRequest();
        }
        #endregion

        #region Update 
        [HttpPut]
        [Route("UpdateProduct")]

        public ActionResult Edit(ProductUpdateDto productToUpdate)
        {
            bool isEdited = productmanger.Update(productToUpdate);

            return isEdited ? Accepted() : BadRequest();
        }
        #endregion

        #region Get All Products 
        [HttpGet]
        [Route("Products")]

        public ActionResult<IEnumerable<ReadAllProductsDto>> GetAllProducts()
        {
            IEnumerable<ReadAllProductsDto> products = productmanger.GetAllProducts();
            return Ok(products);
        }
        #endregion

        #region Get Product By Id 
        [HttpGet]
        [Route("{ProductId}")]
        public ActionResult<ReadProductByIdDto> GetProduct(int productid)
        {
            ReadProductByIdDto? product = productmanger.GetProductById(productid);
            if (product == null) { return NotFound(); }
            return Ok(product);
        }
        #endregion

        #region Get Products By Category Id 
        [HttpGet]
        [Route("Bycategory/{categoryId}")]

        public ActionResult<IEnumerable<ReadProductsByCategoryIdDto>> GetAllProductsByCategoryId(int categoryid)
        {
            IEnumerable<ReadProductsByCategoryIdDto>? products = productmanger.GetProductsByCategoryId(categoryid);
            if (products == null) { return NotFound(); }
            return Ok(products);

        }
        #endregion

        #region Get Products By Discount 
        [HttpGet]
        [Route("Bydiscount")]

        public ActionResult<IEnumerable<ReadProductsByDiscountDto>> GetAllProductsByDiscount()
        {
            IEnumerable<ReadProductsByDiscountDto>? products = productmanger.GetProductsByDiscount();
            if (products == null) { return NotFound(); }
            return Ok(products);

        }
        #endregion

        #region Get Products By Name
        [HttpGet]
        [Route("ByName/{productName}")]

        public ActionResult<IEnumerable<ReadProductsByNameDto>> GetAllProductsByName(string productname)
        {
            IEnumerable<ReadProductsByNameDto>? products = productmanger.GetProductsByName(productname);
            if (products == null) { return NotFound(); }
            return Ok(products);

        }
        #endregion

        #region Get Products By Price 
        [HttpGet]
        [Route("Byprice/{price1,price2}")]

        public ActionResult<IEnumerable<ReadProductsByPriceDto>> GetAllProductsByPrice(int price1,int price2)
        {
            IEnumerable<ReadProductsByPriceDto>? products = productmanger.GetProductsByPrice(price1,price2);
            if (products == null) { return NotFound(); }
            return Ok(products);

        }
        #endregion
    }
}
