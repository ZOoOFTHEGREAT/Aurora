using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class OrderRepo : GenericRepo<Order>, IOrderRepo
{
    private readonly AppDbContext appDbContext;

    public OrderRepo(AppDbContext appDbContext) : base(appDbContext)
    {
        this.appDbContext = appDbContext;

    }

    public List<Order>? GetOrdersByShippingCompanyId(int id)
    {
        return appDbContext.Orders.Where(x => x.ShippingCompanyId == id).ToList();
    }

    public List<Order>? GetOrderssByUserId(int id)
    {
        return appDbContext.Orders.Where(x => x.UserId == id).ToList();
    }
}
