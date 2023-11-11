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
                CreatedDate = addCartDto.CreatedDate,
                UserId = addCartDto.UserId,
                User = addCartDto.User,
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
                User = x.User,

            }
            );
        }
        #endregion

        #region Read Cart Details
        public ReadCartDetailDto? GetCartById(int id)
        {
            Cart? cartRepo = unitOfWork.CartRepo.GetById(id);
            if (cartRepo == null)
            {
                return null;
            }
            return new ReadCartDetailDto
            {
                Id = id,
                CreatedDate = cartRepo.CreatedDate,
                UserId = cartRepo.UserId,
                CartItems = cartRepo.CartItems.Select(x => new ReadCartItemDto {
                    Quantity = x.Quantity,


                }).ToList(),

            };
            
        }
        #endregion

        #region Update Cart 
        public bool UpdateCart(UpdateCartDto updateCartDto)
        {
            Cart? cartUpdate = unitOfWork.CartRepo.GetById(updateCartDto.Id);
            if (cartUpdate == null) { return false; }

            cartUpdate.CreatedDate = updateCartDto.CreatedDate;
            cartUpdate.UserId = updateCartDto.UserId;
            unitOfWork.CartRepo.Update(cartUpdate);
            unitOfWork.SaveChanges();
            return true;
        }
        #endregion   

    }
}

