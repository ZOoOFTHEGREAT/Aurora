using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class OrderRepo : GenericRepo<Order>, IOrderRepo
{
    #region Inject 
    private readonly AppDbContext appDbContext;

    public OrderRepo(AppDbContext appDbContext) : base(appDbContext)
    {
        this.appDbContext = appDbContext;

    }
    #endregion

    #region Get Order By Shipping Company
    public List<Order>? GetOrdersByShippingCompanyId(int ShippingCompanyId)
    {
        return appDbContext.Orders.Where(x => x.ShippingCompanyId == ShippingCompanyId).ToList();
    }
    #endregion

    #region Get Order by user id 
    public List<Order>? GetOrderssByUserId(string UserId)
    {
        return appDbContext.Orders.Where(x => x.UserId == UserId).ToList();
    }
    #endregion
}
