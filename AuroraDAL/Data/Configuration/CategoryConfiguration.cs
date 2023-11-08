using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(x => x.Name)
               .HasColumnType("varchar")
               .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnType("varchar")
                .IsRequired();

            builder.HasMany(x => x.Products)
               .WithOne(x => x.Category)
               .HasForeignKey(x => x.CategoryId);


            //builder.HasData(new List<Category>
            //{
            //    new Category
            //    {
            //        Id=1,
            //        Name="Fashion",
            //        Description="Clothes such as jeans, coats and etc...",
            //    },
            //    new Category
            //    {
            //        Id=2,
            //        Name="Health & Beauty",
            //        Description="Drugs such as makeup, perfumes and etc...",
            //    },
            //    new Category
            //    {
            //        Id=3,
            //        Name="Electronics",
            //        Description="Devices such as Phones, Laptops and etc...",
            //    },

            //});
        }
    }
}
