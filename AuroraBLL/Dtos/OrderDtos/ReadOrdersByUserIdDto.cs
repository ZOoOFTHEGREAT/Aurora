using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Dtos.OrderDtos
{
    public class ReadOrdersByUserIdDto
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Status { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpectedDelivaryDate { get; set; }

        public ShippingCompany ShippingCompany { get; set; } = null!;
        public UserAddress UserAddress { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public virtual ICollection<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();
    }
}
