using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public interface IPaymentDetailRepo:IGenericRepo<PaymentDetail>
{
    List<PaymentDetail>? GetPaymentDetailsByOrderId(int id);
    List<PaymentDetail>? GetPaymentDetailsByUserPayment(int id);
}
