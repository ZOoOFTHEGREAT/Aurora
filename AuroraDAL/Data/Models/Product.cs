using AuroraDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }=string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal DiscountPercent { get; set; }
    public string Description { get; set; } = string.Empty;
    public int? CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public virtual ICollection<CartItem> CartItem { get; set; } = new List<CartItem>();
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

}
