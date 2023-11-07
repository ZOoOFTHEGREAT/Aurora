using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public interface IUnitOfWork
{
    public ICartRepo CartRepo { get; }
    public ICartItemRepo CartItemRepo { get; }
    public ICategoryRepo CategoryRepo { get; }
    public IImageRepo ImageRepo { get; }
    public IOrderRepo OrderRepo { get; }
    public IOrderItemRepo OrderItemRepo { get; }
    public IProductRepo ProductRepo { get; }
    public IPaymentDetailRepo PaymentDetailRepo {get;}
    public IShippingCompanyRepo ShippingCompanyRepo { get; }
    public IUserRepo UserRepo { get; }
    public IUserPaymentRepo UserPaymentRepo { get; }
    public IUserAddressRepo UserAddressRepo { get; }
    int SaveChanges();
}
