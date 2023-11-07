using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class ShippingCompany
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal ServicePrice { get; set; }
    public string WebSite { get; set; } = string.Empty;
    public string Telephone { get; set; } = string.Empty;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();






}
