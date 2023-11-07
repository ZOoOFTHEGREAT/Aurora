using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class PaymentDetailRepo : GenericRepo<PaymentDetail>, IPaymentDetailRepo
{
    #region Inject 
    private readonly AppDbContext appDbContext;

    public PaymentDetailRepo(AppDbContext appDbContext) : base(appDbContext)
    {
          this.appDbContext = appDbContext;  
    }
    #endregion

    #region Get Payment Details By Order Id 
    List<PaymentDetail>? IPaymentDetailRepo.GetPaymentDetailsByOrderId(int OrderId)
    {
          return appDbContext.PaymentDetails.Where(x => x.OrderId == OrderId).ToList();
    }
    #endregion

    #region Get Payment Details By User Payment 
    List<PaymentDetail>? IPaymentDetailRepo.GetPaymentDetailsByUserPayment(int UserPaymentId)
    {
         return appDbContext.PaymentDetails.Where(x => x.UserPaymentId == UserPaymentId).ToList();
    }
    #endregion
}
