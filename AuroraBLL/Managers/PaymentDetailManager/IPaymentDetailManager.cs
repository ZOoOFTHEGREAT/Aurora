using AuroraBLL.Dtos.PaymentDetailDtos;
using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Managers.PaymentDetailManager
{
    public interface IPaymentDetailManager
    {
        public IEnumerable<ReadAllPaymentDetailsDto> GetAllPaymentDetails();
        IEnumerable<ReadPaymentDetailsByOrderIdDto>? GetPaymentDetailByOrderID(int OrderId);
        IEnumerable<ReadPaymentDetailsByUserPaymentDto>? GetPaymentDetailByUserPaymentId(int UserPaymentId);

    }
}
