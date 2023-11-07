using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext appDbContext;

    public ICartRepo CartRepo { get; }

    public ICartItemRepo CartItemRepo { get; }

    public ICategoryRepo CategoryRepo { get; }

    public IImageRepo ImageRepo { get; }

    public IOrderRepo OrderRepo { get; }

    public IOrderItemRepo OrderItemRepo { get; }
                                  
    public IProductRepo ProductRepo { get; }

    public IPaymentDetailRepo PaymentDetailRepo { get; }

    public IShippingCompanyRepo ShippingCompanyRepo { get; }

    public IUserRepo UserRepo { get; }

    public IUserPaymentRepo UserPaymentRepo { get; }

    public IUserAddressRepo UserAddressRepo { get; }
   
    public UnitOfWork
    (
     AppDbContext     appDbContext,
     IProductRepo     productRepo,
     IUserAddressRepo userAddressRepo,
     IUserPaymentRepo userPaymentRepo,
     IUserRepo        userRepo, 
     IShippingCompanyRepo shippingCompanyRepo,
     IPaymentDetailRepo   paymentDetailRepo, 
     IOrderItemRepo       orderItemRepo,
     IOrderRepo           orderRepo,
     IImageRepo           imageRepo , 
     ICategoryRepo        categoryRepo,
     ICartItemRepo        cartItemRepo ,
     ICartRepo             cartRepo
    )
    {
        this.appDbContext = appDbContext;
        this.ProductRepo = productRepo;
        this.UserAddressRepo = userAddressRepo;
        this.UserPaymentRepo = userPaymentRepo;
        this.UserRepo = userRepo;
        this.CartRepo= cartRepo;
        this.CategoryRepo= categoryRepo;
        this.CartItemRepo= cartItemRepo;
        this.ImageRepo = imageRepo;
        this.OrderRepo= orderRepo;
        this.PaymentDetailRepo=paymentDetailRepo;
        this.OrderItemRepo= orderItemRepo;
        this.ShippingCompanyRepo = shippingCompanyRepo;
    }

    public int SaveChanges()
    {
      return appDbContext.SaveChanges();
    }
}
