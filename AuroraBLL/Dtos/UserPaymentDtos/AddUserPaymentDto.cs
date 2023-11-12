using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Dtos.UserPaymentDtos
{
    public class AddUserPaymentDto
    {
        public string PaymentType { get; set; } = string.Empty;
        public string Provider { get; set; } = string.Empty;
        public int AccountNumber { get; set; }
        public DateTime ExpireDate { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
