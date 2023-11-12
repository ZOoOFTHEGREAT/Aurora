using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL.Data.Configuration
{
    public class PaymentDetailConfiguration : IEntityTypeConfiguration<PaymentDetail>
    {
        public void Configure(EntityTypeBuilder<PaymentDetail> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(x => x.Amount)
               .HasColumnType("int")
               .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(x => x.Date)
                .HasColumnType("date")
                .IsRequired();

            builder.HasOne(x => x.UserPayment)
               .WithMany(x => x.PaymentDetails)
               .HasForeignKey(x => x.UserPaymentId)
               .OnDelete(DeleteBehavior.NoAction)    
               .IsRequired();


            //builder.HasData(new List<PaymentDetail>
            //{
            //    new PaymentDetail
            //    {
            //        Id=1,
            //        Amount=1000,
            //        Date=DateTime.Now,
            //        Status=true
            //    },
            //    new PaymentDetail
            //    {
            //        Id=2,
            //        Amount=2000,
            //        Date=DateTime.Now,
            //        Status=true
            //    },
            //     new PaymentDetail
            //    {
            //        Id=3,
            //        Amount=3000,
            //        Date=DateTime.Now,
            //        Status=false
            //    },

            //});
        }
    }
}

