using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Dtos.ProductDtos
{
    public class ReadProductsByPriceDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal DiscountPercent { get; set; }
        public string Description { get; set; } = string.Empty;
        public Category Category { get; set; } = null!;
        public virtual ICollection<Image> Images { get; set; } = new List<Image>();
    }
}
