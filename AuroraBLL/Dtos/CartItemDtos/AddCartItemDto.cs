using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Dtos.CartItemDtos
{
    public class AddCartItemDto
    {
        public int Quantity { get; set; }
        public int? CartId { get; set; }
        public int? ProductId { get; set; }
    }
}
