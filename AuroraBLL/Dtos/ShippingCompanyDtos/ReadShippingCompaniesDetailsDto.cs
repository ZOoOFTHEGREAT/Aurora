using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Dtos.ShippingCompanyDtos
{
    public class ReadShippingCompaniesDetailsDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal ServicePrice { get; set; }
        public string WebSite { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
    }
}
