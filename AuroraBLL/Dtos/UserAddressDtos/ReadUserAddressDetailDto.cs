using AuroraBLL.Dtos.OrderDtos;
using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Dtos.UserAddressDtos
{
    public class ReadUserAddressDetailDto
    {
        public int Id { get; set; }
        public string Address { get; set; } = string.Empty;
        public string LineOne { get; set; } = string.Empty;
        public string? LineTwo { get; set; }
        public string Country { get; set; } = string.Empty;
        public string City    { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
    }
}
