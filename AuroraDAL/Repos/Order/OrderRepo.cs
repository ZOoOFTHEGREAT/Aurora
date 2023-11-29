using Microsoft.EntityFrameworkCore;
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
        return appDbContext.Set<Order>().
           Include(Order => Order.PaymentDetails).
           Include(Order => Order.OrderItems).
           ThenInclude(OrderItems => OrderItems.Product).
           Where(x => x.ShippingCompanyId == ShippingCompanyId).ToList();
    }
    #endregion

    #region Get Order by user id 
    public List<Order>? GetOrderssByUserId(string UserId)
    {
        return appDbContext.Set<Order>().
            Include(Order => Order.PaymentDetails).
            Include(Order => Order.OrderItems).
            ThenInclude(OrderItems => OrderItems.Product).
            Where(Order => Order.UserId == UserId).ToList();

    }
    #endregion

    public new List<Order> GetAll()
    {
        return appDbContext.Set<Order>().
            Include(Order => Order.PaymentDetails).
            Include(Order => Order.OrderItems).
            ThenInclude(OrderItems => OrderItems.Product).ToList();
    }
    public new Order? GetById(int id)
    {
        return appDbContext.Set<Order>().
            Include(Order => Order.PaymentDetails).
            Include(Order => Order.OrderItems).ThenInclude(OrderItems => OrderItems.Product).
            FirstOrDefault(Order => Order.Id == id);
    }
}
