using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Dtos.UserPaymentDtos
{
    public class ReadUserPaymentDto
    {
        public string   PaymentType    { get; set; } = string.Empty;
        public string   Provider       { get; set; } = string.Empty;
        public int      AccountNumber { get; set; }
        public DateTime ExpireDate    { get; set; }
    }
}
