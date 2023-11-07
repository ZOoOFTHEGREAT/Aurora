using AuroraDAL;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class AppDbContext:IdentityDbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Image> Images { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItemRepo> CartItems  { get; set; }
    public DbSet<Order> Orders{ get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<UserAddress> UserAddresses { get; set; }
    public DbSet<UserPayment> UserPayments { get; set; }
    public DbSet<ShippingCompany> ShippingCompanies { get; set; }
    public DbSet<PaymentDetail> PaymentDetails { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
