using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AuroraDAL.Data.Configuration
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(x => x.Quantity)
               .HasColumnType("int")
               .IsRequired();

            builder.HasOne(x => x.Cart)
              .WithMany(x => x.CartItems)
              .HasForeignKey(x => x.CartId)
             .IsRequired();

            builder.HasOne(x => x.Product)
            .WithOne(x => x.CartItem)
            .HasForeignKey<CartItem>(x => x.ProductId)
            .IsRequired();

          


        }

       
    }
}
