using AuroraBLL.Dtos.OrderItemDtos;
using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Dtos.OrderDtos
{
    public class ReadOrdersByShippingCompanyIdDto
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Status { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpectedDelivaryDate { get; set; }

        public int? AddressId { get; set; }
        public virtual ICollection<ReadOrderItemDto> OrderItems { get; set; } = new List<ReadOrderItemDto>();
    }
}
