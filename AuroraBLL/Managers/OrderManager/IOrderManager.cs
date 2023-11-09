using AuroraBLL.Dtos.ImageDtos;
using AuroraBLL.Dtos.OrderDtos;
using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Managers.OrderManager
{
    public interface IOrderManager
    {
        bool Add(OrderAddDto Ordertobeadded);
        bool Update(OrderUpdateDto ordertobeupdated);
        bool Delete(int orderid);
        ReadOrderByIdDto? GetOrderById(int orderid);
        IEnumerable<ReadOrdersByShippingCompanyIdDto> GetOrdersByShippingCompanyId(int shippingcompanyId);
        IEnumerable<ReadOrdersByUserIdDto> GetOrdersByUserId(string userId);
    }
}
