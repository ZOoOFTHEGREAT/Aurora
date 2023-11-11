using AuroraBLL.Dtos;
using AuroraBLL.Dtos.CartDtos;
using AuroraBLL.Dtos.CategoryDtos;
using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Managers.CartManager
{
    public interface ICartManager
    {
        IEnumerable<ReadCartDto> GetAll();
        ReadCartDetailDto? GetCartByUserId(string userid);
        int AddCart(AddCartDto addCartDto);
        bool UpdateCart(UpdateCartDto updateCartDto);
        bool DeleteCart(int id);
    }
}
