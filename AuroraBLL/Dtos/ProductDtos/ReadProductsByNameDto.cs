using AuroraBLL.Dtos.ImageDtos;
using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Dtos.ProductDtos
{
    public class ReadProductsByNameDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal DiscountPercent { get; set; }
        public string Description { get; set; } = string.Empty;
        public int? CategoryId { get; set; }
        public virtual ICollection<ReadImageDto> Images { get; set; } = new List<ReadImageDto>();
    }
}
