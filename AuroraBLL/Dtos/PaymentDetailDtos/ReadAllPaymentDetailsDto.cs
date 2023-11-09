using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Dtos.PaymentDetailDtos
{
    public class ReadAllPaymentDetailsDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
        public int OrderId { get; set; }
        public int UserPaymentId { get; set; }
    }
}
