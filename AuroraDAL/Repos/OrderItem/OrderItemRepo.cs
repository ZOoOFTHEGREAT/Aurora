using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class OrderItemRepo : GenericRepo<OrderItem>, IOrderItemRepo
{
    private readonly AppDbContext appDbContext;

    public OrderItemRepo(AppDbContext appDbContext) : base(appDbContext)
    {
        this.appDbContext = appDbContext;
    }
    public OrderItem? GetOrderItemByOrderId(int OrderId) => appDbContext.Set<OrderItem>()
      .FirstOrDefault(i => i.OrderId == OrderId);
}
