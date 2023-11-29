﻿using AuroraBLL.Dtos.OrderItemDtos;
using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraBLL.Dtos.OrderDtos
{
    public class OrderAddDto
    {
        public decimal TotalPrice { get; set; }

        public string UserId { get; set; } = string.Empty;
        public int? ShippingCompanyId { get; set; }
        public int? AddressId { get; set; }
    }
}
