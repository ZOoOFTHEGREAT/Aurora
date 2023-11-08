using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL.Data.Configuration
{
    public class Orderconfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(x => x.TotalPrice)
               .HasPrecision(10, 2)
               .IsRequired();

            builder.Property(x => x.Status)
               .HasColumnType("bit");

            builder.Property(x => x.DeliveryDate)
               .HasColumnType("date")
               .IsRequired();

            builder.Property(x => x.CreatedAt)
               .HasColumnType("date")
               .IsRequired();

            builder.Property(x => x.ExpectedDelivaryDate)
               .HasColumnType("date");

            builder.HasOne(x => x.User)
               .WithMany(x => x.Orders)
               .HasForeignKey(x => x.UserId)
               .IsRequired();

            builder.HasMany(x => x.PaymentDetails)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId)
                .IsRequired();


            builder.HasOne(x => x.ShippingCompany)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.ShippingCompanyId)
                .IsRequired();

            builder.HasOne(x => x.UserAddress)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.AddressId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

            //builder.HasData(new List<Order>
            //{

            //    new Order
            //    {
            //    Id = 1,
            //    Status = true,
            //    DeliveryDate = DateTime.Now.AddDays(3),
            //    CreatedAt = DateTime.Now,
            //    ExpectedDelivaryDate = DateTime.Now.AddDays(5) ,
            //    },


            //    new Order
            //    {
            //    Id = 2,
            //    Status = true,
            //    DeliveryDate = DateTime.Now.AddDays(3),
            //    CreatedAt = DateTime.Now,
            //    ExpectedDelivaryDate = DateTime.Now.AddDays(5),
            //    },

            //    new Order
            //    {
            //    Id = 1,
            //    Status = true,
            //    DeliveryDate = DateTime.Now.AddDays(3),
            //    CreatedAt = DateTime.Now,
            //    ExpectedDelivaryDate = DateTime.Now.AddDays(5),
            //    },

            //});


        }
    }
}
