using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class UserAddress
{

    public int Id { get; set; }
    public string Address { get; set; } = string.Empty;
    public string LineOne { get; set; } = string.Empty;
    public string? LineTwo { get; set; }
    public string Country { get; set;}= string.Empty;
    public string City { get; set; } = string.Empty;
    public int? UserId { get; set; }
    public User User { get; set; } = null!;
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();


}
