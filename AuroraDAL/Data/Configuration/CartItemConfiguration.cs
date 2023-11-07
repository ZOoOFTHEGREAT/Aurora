using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
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
            .WithMany(x => x.CartItem)
            .HasForeignKey(x => x.ProductId)
>>>>>>> aa42228b0aab2564633bf65df6994927db297703
            .IsRequired();


        }

       
    }
}
