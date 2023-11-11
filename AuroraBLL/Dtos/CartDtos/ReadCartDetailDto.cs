using AuroraBLL.Dtos.CartItemDtos;
using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Dtos.CartDtos
{
    public class ReadCartDetailDto
    {
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<ReadCartItemDetailDto> CartItems { get; set; } = new List<ReadCartItemDetailDto>();
    }
}
