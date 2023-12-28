using AuroraBLL.Dtos.ImageDtos;
using AuroraBLL.Dtos.OrderDtos;
using AuroraBLL.Dtos.ProductDtos;
using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Managers.ProductManager
{
    public class ProductManager : IProductManager
    {
        #region Inject
        private readonly IUnitOfWork _IUnitOfWork;

        public ProductManager(IUnitOfWork unitOfWork)
        {
            _IUnitOfWork = unitOfWork;

        }

        public IUnitOfWork? UnitOfWork { get; }
        #endregion

        #region Add
        public bool Add(ProductAddDto product)
        {
            Product? producttoadd = new Product();

            producttoadd.Name = product.Name;
            producttoadd.Price = product.Price;
            producttoadd.DiscountPercent = product.DiscountPercent;
            producttoadd.Quantity = product.Quantity;
            producttoadd.Description = product.Description;
            producttoadd.CategoryId = product.CategoryId;
            producttoadd.DiscountPercent = 0;

            _IUnitOfWork.ProductRepo.Add(producttoadd);
            _IUnitOfWork.SaveChanges();
            return true;
        }
        #endregion

        #region Delete
        public bool Delete(int productid)
        {
            Product? producttobedeleted = _IUnitOfWork.ProductRepo.GetById(productid);
            if (producttobedeleted == null)
            {
                return false;
            }
            _IUnitOfWork.ProductRepo.Delete(producttobedeleted);

            IEnumerable<Image>? imagestodelete = _IUnitOfWork.ImageRepo.GetImagesByProductId(productid);
            if (imagestodelete != null)
            {
                foreach (var image in imagestodelete)
                {
                    _IUnitOfWork.ImageRepo.Delete(image);
                }
            }
            _IUnitOfWork.SaveChanges();
            return true;
        }
        #endregion

        #region update
        public bool Update(ProductUpdateDto product)
        {
            Product? producttoupdate = _IUnitOfWork.ProductRepo.GetById(product.Id);
            if (producttoupdate == null)
            {
                return false;
            }

            producttoupdate.Name = product.Name;
            producttoupdate.Price = product.Price;
            producttoupdate.Quantity = product.Quantity;
            producttoupdate.DiscountPercent = product.DiscountPercent;
            producttoupdate.Description = product.Description;
            producttoupdate.CategoryId = product.CategoryId;

        _IUnitOfWork.ProductRepo.Update(producttoupdate);
            _IUnitOfWork.SaveChanges();
            return true;
        }
        #endregion

        #region Get All Products
        public IEnumerable<ReadAllProductsDto> GetAllProducts()
        {
            IEnumerable<Product>? productsfromdb = _IUnitOfWork.ProductRepo.GetAll();
            if (productsfromdb == null)
            {
                return Enumerable.Empty<ReadAllProductsDto>();
            }
            return productsfromdb.Select(p => new ReadAllProductsDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity,
                DiscountPercent = p.DiscountPercent,
                Description = p.Description,
                CategoryId = p.CategoryId,
                Images = p.Images.Select(image => new ReadImageDto
                {
                    ImageUrl = image.ImageUrl,
                }).ToList(),
            });
        }
        #endregion

        #region Get Product By Id
        public ReadProductByIdDto? GetProductById(int productid)
        {
            Product? productfromdb = _IUnitOfWork.ProductRepo.GetById(productid);
            if (productfromdb == null)
            {
                return null;
            }
            ReadProductByIdDto producttoreturn = new ReadProductByIdDto();

            producttoreturn.Name = productfromdb.Name;
            producttoreturn.Price = productfromdb.Price;
            producttoreturn.Quantity = productfromdb.Quantity;
            producttoreturn.DiscountPercent = productfromdb.DiscountPercent;
            producttoreturn.Description = productfromdb.Description;
            producttoreturn.CategoryId = productfromdb.CategoryId;
            producttoreturn.Images = productfromdb.Images.Select(image => new ReadImageDto
            {
                ImageUrl = image.ImageUrl,
            }).ToList();

            return producttoreturn;
        }
        #endregion

        #region Get Products By Category Id
        public IEnumerable<ReadProductsByCategoryIdDto> GetProductsByCategoryId(int categoryid)
        {
            IEnumerable<Product>? productsfromdb = _IUnitOfWork.ProductRepo.GetProductByCategory(categoryid);
            if (productsfromdb == null)
            {
                return Enumerable.Empty<ReadProductsByCategoryIdDto>();
            }
            return productsfromdb.Select(p => new ReadProductsByCategoryIdDto
            {
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity,
                DiscountPercent = p.DiscountPercent,
                Description = p.Description,
                Images = p.Images.Select(image => new ReadImageDto
                {
                    ImageUrl = image.ImageUrl,
                }).ToList(),
            }
            );
        }
        #endregion

        #region Get Products By Discount
        public IEnumerable<ReadProductsByDiscountDto> GetProductsByDiscount()
        {
            IEnumerable<Product>? productsfromdb = _IUnitOfWork.ProductRepo.GetProductByDiscount();
            if (productsfromdb == null)
            {
                return Enumerable.Empty<ReadProductsByDiscountDto>();
            }
            return productsfromdb.Select(p => new ReadProductsByDiscountDto
            {
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity,
                DiscountPercent = p.DiscountPercent,
                Description = p.Description,
                Images = p.Images.Select(image => new ReadImageDto
                {
                    ImageUrl = image.ImageUrl,
                }).ToList(),
                CategoryId = p.CategoryId
            }
            );
        }
        #endregion

        #region Get Products By Name
        public IEnumerable<ReadProductsByNameDto> GetProductsByName(string productname)
        {
            IEnumerable<Product>? productsfromdb = _IUnitOfWork.ProductRepo.GetProductByName(productname);
            if (productsfromdb == null)
            {
                return Enumerable.Empty<ReadProductsByNameDto>();
            }
            return productsfromdb.Select(p => new ReadProductsByNameDto
            {
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity,
                DiscountPercent = p.DiscountPercent,
                Description = p.Description,
                Images = p.Images.Select(image => new ReadImageDto
                {
                    ImageUrl = image.ImageUrl,
                }).ToList(),
                CategoryId = p.CategoryId
            }
            );
        }
        #endregion

        #region Get Products By Price
        public IEnumerable<ReadProductsByPriceDto> GetProductsByPrice(int minimumprice, int maximumprice)
        {
            if(minimumprice>maximumprice)
            {
                var X = minimumprice;
                minimumprice = maximumprice;
                maximumprice = X;
            }

            IEnumerable<Product>? productsfromdb = _IUnitOfWork.ProductRepo.GetProductByPrice(minimumprice, maximumprice);
            if (productsfromdb == null)
            {
                return Enumerable.Empty<ReadProductsByPriceDto>();
            }
            return productsfromdb.Select(p => new ReadProductsByPriceDto
            {
                Name = p.Name,
                Price = p.Price,
                Quantity = p.Quantity,
                DiscountPercent = p.DiscountPercent,
                Description = p.Description,
                Images = p.Images.Select(image => new ReadImageDto
                {
                    ImageUrl = image.ImageUrl,
                }).ToList(),
                CategoryId = p.CategoryId
            }
            );
        }
        #endregion
    }
}
