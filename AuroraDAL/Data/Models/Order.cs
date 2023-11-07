using AuroraDAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class Order
{
    public int Id { get; set; }
    public decimal TotalPrice { get; set; }
    public bool Status { get; set; }
    public DateTime DeliveryDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime ExpectedDelivaryDate { get; set; }


    public int? UserId { get; set; }
    
    public int? ShippingCompanyId { get; set; }
    public int? AddressId { get; set; }

    public  User User { get; set; } = null!;
    public ShippingCompany ShippingCompany { get; set; } = null!;   
    public UserAddress UserAddress { get; set; } = null!;
    public virtual ICollection<OrderItem> OrderItems { get; set; }=new List<OrderItem>();
    public virtual ICollection<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();







}
