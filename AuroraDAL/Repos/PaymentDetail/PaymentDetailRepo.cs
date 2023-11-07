using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class PaymentDetailRepo : GenericRepo<PaymentDetail>, IPaymentDetailRepo
{
    public PaymentDetailRepo(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
