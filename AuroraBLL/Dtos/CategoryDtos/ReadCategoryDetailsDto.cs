using AuroraBLL.Dtos.ProductDtos;
using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Dtos.CategoryDtos
{
    public class ReadCategoryDetailsDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public virtual ICollection<ReadProductByIdDto> Products { get; set; } = new List<ReadProductByIdDto>();

    }
}
