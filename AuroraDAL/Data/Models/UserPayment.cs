﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class UserPayment
{
    public int Id { get; set; }
    public string PaymentType { get; set; } = string.Empty;
    public string Provider { get; set; } = string.Empty;

    public string? AccountNumber { get; set; }
    public DateTime ExpireDate { get; set; }

    public string UserId { get; set; } = string.Empty;
    public User User { get; set; } = null!;

    public ICollection<PaymentDetail> PaymentDetails= new List<PaymentDetail>();



}
