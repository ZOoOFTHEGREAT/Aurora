using AuroraBLL.Dtos.CartDtos;
using AuroraBLL.Dtos.OrderItemDtos;
using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Managers.OrderItemManager
{
   public interface IOrderItemManager
    {
        IEnumerable<ReadOrderItemsByOrderIdDto>? GetOrderItemsByOrderId(int orderid);
        int AddOrderItem(AddOrderItemDto addOrderItem);
        bool UpdateOrderItem(UpdateOrderItemDto updateOrderItemDto);
        bool DeleteOrderItem(int id);
    }
}
