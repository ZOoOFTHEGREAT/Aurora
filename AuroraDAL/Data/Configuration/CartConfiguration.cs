using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AuroraDAL.Data.Configuration
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(x => x.CreatedDate)
               .HasColumnType("Date")
               .IsRequired();



            builder.HasOne(x => x.User)
                .WithOne(x=>x.Cart)
                .HasForeignKey<Cart>(x => x.UserId)
                .IsRequired();

          


        }
    }
}
