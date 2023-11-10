using AuroraBLL.Dtos.CartDtos;
using AuroraBLL.Dtos.CartItemDtos;
using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Managers.CartItemManager
{
    public class cartItemManager : ICartItemManager
    {
        #region inject 
        private readonly IUnitOfWork unitOfWork; 
        public cartItemManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        #endregion

        #region Add Cart Item
        public int AddCartItem(AddCartItemDto cartItemAdd) 
        {
            CartItem AddCart = new CartItem();
            {
                AddCart.Quantity = cartItemAdd.Quantity;
                AddCart.CartId = cartItemAdd.CartId;
                AddCart.ProductId = cartItemAdd.ProductId;  
                

            }
            unitOfWork.CartItemRepo.Add(AddCart);
            return unitOfWork.SaveChanges();
        }
        #endregion

        #region Delete CartItem
        public bool IsDelete(int id)
        {
            CartItem? cartItemDelete = unitOfWork.CartItemRepo.GetById(id);
            if (cartItemDelete == null) { return false; }
            unitOfWork.CartItemRepo.Delete(cartItemDelete);
            unitOfWork.SaveChanges();
            return true;
        }
        #endregion

        #region Read data
        public IEnumerable<ReadCartItemDto> GetAll()
        {
            IEnumerable<CartItem> CartItemFromDb = unitOfWork.CartItemRepo.GetAll();
            return CartItemFromDb.Select(x => new ReadCartItemDto
            {
                 Id = x.Id,
                 Quantity = x.Quantity,
                 CartId = x.CartId,
                 ProductId = x.ProductId,

            }
            );
        }
        #endregion

        #region read data by details
        public ReadCartItemDetailDto? readCartItemDetailDto(int id)
        {
            CartItem? cartItemRepo = unitOfWork.CartItemRepo.GetById(id);
            if (cartItemRepo == null)
            {
                return null;
            }
            return new ReadCartItemDetailDto
            {
                Id = cartItemRepo.Id,
                Quantity = cartItemRepo.Quantity,
                CartId = cartItemRepo.CartId,
                ProductId = cartItemRepo.ProductId,
                //Check
                Product =new Product() { Name = cartItemRepo.Product.Name },

                
            };
        }
        #endregion region

        #region Item to Update
        public bool Update(UpdateCartItemDto cartItemUpdate)
        {
            CartItem? ItemUpdate = unitOfWork.CartItemRepo.GetById(cartItemUpdate.Id);
            if (ItemUpdate == null) { return false; }

            ItemUpdate.Id = cartItemUpdate.Id;
            ItemUpdate.Quantity = cartItemUpdate.Quantity;
            ItemUpdate.ProductId = cartItemUpdate.ProductId;
            unitOfWork.CartItemRepo.Update(ItemUpdate);
     
            return unitOfWork.SaveChanges() > 0 ;
        }
    }
    #endregion
}
