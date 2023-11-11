using AuroraBLL.Dtos.PaymentDetailDtos;
using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Dtos.UserPaymentDtos
{
    public class ReadUserPaymentDetailDto
    {
        public int Id { get; set; }
        public string PaymentType { get; set; } = string.Empty;
        public string Provider { get; set; } = string.Empty;
        public int AccountNumber { get; set; }
        public DateOnly ExpireDate { get; set; }
        public string UserId { get; set; } = string.Empty;
        //PaymentDetailDto needed
        public ICollection<ReadPaymentDetailsDto> PaymentDetails = new List<ReadPaymentDetailsDto>();
    }
}
