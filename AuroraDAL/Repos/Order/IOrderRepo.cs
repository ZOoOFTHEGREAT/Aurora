using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public interface IOrderRepo:IGenericRepo<Order>
{
    List<Order>? GetOrderssByUserId(string id);
    List<Order>? GetOrdersByShippingCompanyId(int id);
    new List<Order> GetAll();
    new Order? GetById(int id);
}
