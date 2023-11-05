using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class PaymentDetail
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public bool Status { get; set; }
    public DateTime Date { get; set; }

    public Order Order { get; set; } = null!;
}
