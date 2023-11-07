using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class OrderItemRepo : GenericRepo<OrderItem>, IOrderItemRepo
{
    public OrderItemRepo(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
