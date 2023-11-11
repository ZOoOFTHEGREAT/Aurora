using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Dtos.ShippingCompanyDtos
{
    public class ReadShippingCompaniesDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int NumberOfOrders { get; set; }

    }
}
