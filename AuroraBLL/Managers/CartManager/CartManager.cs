using AuroraBLL.Dtos;
using AuroraBLL.Dtos.CartDtos;
using AuroraBLL.Dtos.CartItemDtos;
using AuroraBLL.Dtos.CategoryDtos;
using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Managers.CartManager
{
    public class CartManager : ICartManager
    {
        #region Inject
        private readonly IUnitOfWork unitOfWork;
        public CartManager(IUnitOfWork unitOfWork)
        {

            this.unitOfWork = unitOfWork;

        }
        #endregion

        #region Add to Cart
        public int AddCart(AddCartDto addCartDto)
        {
            Cart cartRequested = new Cart()
            {
                CreatedDate = DateTime.Now,
                UserId = addCartDto.UserId,
            };
            unitOfWork.CartRepo.Add(cartRequested);
            return unitOfWork.SaveChanges();

        }

        #endregion

        #region Delete Cart
        public bool DeleteCart(int id)
        {
            Cart? cartDelete = unitOfWork.CartRepo.GetById(id);
            if (cartDelete == null) { return false; }
            unitOfWork.CartRepo.Delete(cartDelete);
            unitOfWork.SaveChanges();
            return true;
        }
        #endregion

        #region Read Cart
        public IEnumerable<ReadCartDto> GetAll()
        {
            IEnumerable<Cart> CartFromDb = unitOfWork.CartRepo.GetAll();
            return CartFromDb.Select(x => new ReadCartDto
            {
                Id = x.Id,
                CreatedDate = x.CreatedDate,

            }
            );
        }
        #endregion

        #region Read Cart Details
        public ReadCartDetailDto? GetCartByUserId(string userid)
        {
            Cart? cartRepo = unitOfWork.CartRepo.GetCartByUserId(userid);
            if (cartRepo == null)
            {
                return null;
            }
            return new ReadCartDetailDto
            {
                CreatedDate = cartRepo.CreatedDate,
                CartItems = cartRepo.CartItems.Select(x => new ReadCartItemDetailDto
                {
                    Quantity = x.Quantity,
                }).ToList(),

            };
            
        }
        #endregion
    }
}

