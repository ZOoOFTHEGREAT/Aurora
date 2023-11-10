using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Dtos.CartItemDtos
{
    public class ReadCartItemDetailDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int? CartId { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; } = null!;
        public Cart Cart { get; set; } = null!;
    }
}
