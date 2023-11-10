using AuroraBLL.Dtos.CartItemDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Managers.CartItemManager
{
    public interface ICartItemManager
    {
        IEnumerable<ReadCartItemDto> GetAll();
        ReadCartItemDetailDto? readCartItemDetailDto(int id);
        public int AddCartItem(AddCartItemDto cartItemAdd);
        public bool Update(UpdateCartItemDto cartItemUpdate);
        public bool IsDelete(int id); 
    }
}
