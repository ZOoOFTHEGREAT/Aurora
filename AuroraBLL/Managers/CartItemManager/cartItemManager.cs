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
        public IEnumerable<ReadCartItemDto>? GetCartItemsByCartId(int cartid)
        {
            IEnumerable<CartItem>? CartItemsFromDb = unitOfWork.CartItemRepo.GetCartItemByCartId(cartid);
            if(CartItemsFromDb == null) { return null; }
            return CartItemsFromDb.Select(x => new ReadCartItemDto
            {
                 Quantity = x.Quantity,
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
                Quantity = cartItemRepo.Quantity,
                ProductId = cartItemRepo.ProductId,               
            };
        }
        #endregion region

        #region Item to Update
        public bool Update(UpdateCartItemDto cartItemUpdate)
        {
            CartItem? ItemUpdate = unitOfWork.CartItemRepo.GetById(cartItemUpdate.Id);
            if (ItemUpdate == null) { return false; }

            ItemUpdate.Quantity = cartItemUpdate.Quantity;
            unitOfWork.CartItemRepo.Update(ItemUpdate);
            unitOfWork.SaveChanges();

            return true  ;
        }
    }
    #endregion
}
