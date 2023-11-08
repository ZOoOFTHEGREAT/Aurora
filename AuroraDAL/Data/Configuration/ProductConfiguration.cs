using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL.Data.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(x => x.Name)
               .HasColumnType("varchar")
               .IsRequired();

            builder.Property(x => x.Price)
               .HasColumnType("int")
               .IsRequired();

            builder.Property(x => x.Quantity)
               .HasColumnType("int")
               .IsRequired();

            builder.Property(x => x.DiscountPercent)
               .HasColumnType("int");

            builder.Property(x => x.Description)
               .HasColumnType("varchar")
               .IsRequired();


        }
    }
}
