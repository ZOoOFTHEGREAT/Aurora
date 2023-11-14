using AuroraBLL.Dtos.OrderItemDtos;
using AuroraBLL.Dtos.PaymentDetailDtos;
using AuroraBLL.Dtos.UserPaymentDtos;
using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Dtos.OrderDtos
{
    public class ReadOrderByIdDto
    {
        public decimal TotalPrice { get; set; }
        public bool Status { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }

        public string UserId { get; set; } = string.Empty;

        public int? ShippingCompanyId { get; set; }
        public int? AddressId { get; set; }
        public virtual ICollection<ReadOrderItemDto> OrderItems { get; set; } = new List<ReadOrderItemDto>();
        public virtual ICollection<ReadPaymentDetailsDto> PaymentDetails { get; set; } = new List<ReadPaymentDetailsDto>();
    }
}
