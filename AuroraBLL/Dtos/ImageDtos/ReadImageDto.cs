using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Dtos.ImageDtos
{
    public class ReadImageDto
    {
        public string ImageUrl { get; set; } = string.Empty;
        public int? ProductId { get; set; }
    }
}
