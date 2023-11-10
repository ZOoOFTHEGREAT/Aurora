using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public interface IOrderItemRepo:IGenericRepo<OrderItem>
{
    List<OrderItem>? GetOrderItemByOrderId(int OrderId);
}
