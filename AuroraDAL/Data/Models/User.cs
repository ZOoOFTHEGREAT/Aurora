using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class User:IdentityUser
{
    public string Fname { get; set; } = string.Empty;
    public string Lname { get; set; } = string.Empty;

    public Cart Cart { get; set; } = null!;
    public virtual ICollection<Order> Orders { get; set; }=new List<Order>();
    public virtual ICollection<UserPayment> UserPayments { get; set; } = new List<UserPayment>();

    public virtual ICollection<UserAddress> UserAddresses { get; set; } = new List<UserAddress>();

}
