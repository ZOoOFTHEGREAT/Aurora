using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class OrderItemRepo : GenericRepo<OrderItem>, IOrderItemRepo
{
    #region Inject 
    private readonly AppDbContext appDbContext;

    public OrderItemRepo(AppDbContext appDbContext) : base(appDbContext)
    {
        this.appDbContext = appDbContext;
    }
    #endregion

    #region Get Order Items By Order Id 
    public List<OrderItem> GetOrderItemByOrderId(int OrderId)
        => appDbContext.Set<OrderItem>()
      .Where(i => i.OrderId == OrderId).ToList();
    #endregion

}
