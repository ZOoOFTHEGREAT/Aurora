using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AuroraDAL.Data.Configuration
{
    public class ShippingCompanyConfiguration : IEntityTypeConfiguration<ShippingCompany>
    {
        public void Configure(EntityTypeBuilder<ShippingCompany> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(x => x.Name)
               .HasColumnType("varchar(MAX)")
               .IsRequired();

            builder.Property(x => x.ServicePrice)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.WebSite)
               .HasColumnType("varchar(MAX)")
               .IsRequired();

            builder.Property(x => x.Telephone)
                .HasColumnType("varchar(MAX)")
                .IsRequired();


            builder.HasData(new List<ShippingCompany>
            {
                new ShippingCompany
                {
                    Id=1,
                    Name="DHL",
                    ServicePrice=400,
                    WebSite="https://www.dhl.com/eg-en/home.html?locale=true",
                    Telephone="+202 25943200"
                },
                new ShippingCompany
                {
                    Id=2,
                    Name="FedEx",
                    ServicePrice=500,
                    WebSite="https://www.fedex.com/en-us/home.html",
                    Telephone="012 07575333"
                },
                new ShippingCompany
                {
                    Id=3,
                    Name="UPS",
                    ServicePrice=600,
                    WebSite="https://www.ups.com/sa/ar/Home.page",
                    Telephone="+202 24141456"
                },

            });
        }
    }
}
