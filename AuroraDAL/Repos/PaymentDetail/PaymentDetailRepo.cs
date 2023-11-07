using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class PaymentDetailRepo : GenericRepo<PaymentDetail>, IPaymentDetailRepo
{
    private readonly AppDbContext appDbContext;

    public PaymentDetailRepo(AppDbContext appDbContext) : base(appDbContext)
    {
          this.appDbContext = appDbContext;  
    }

    List<PaymentDetail>? IPaymentDetailRepo.GetPaymentDetailsByOrderId(int id)
    {
          return appDbContext.PaymentDetails.Where(x => x.OrderId == id).ToList();
    }

    List<PaymentDetail>? IPaymentDetailRepo.GetPaymentDetailsByUserPayment(int id)
    {
         return appDbContext.PaymentDetails.Where(x => x.UserPaymentId == id).ToList();
    }
}
