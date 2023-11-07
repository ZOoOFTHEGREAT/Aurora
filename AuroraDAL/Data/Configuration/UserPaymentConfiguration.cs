using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class UserPaymentConfiguration : IEntityTypeConfiguration<UserPayment>
{
    public void Configure(EntityTypeBuilder<UserPayment> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Id).ValueGeneratedOnAdd();

        builder.Property(i => i.PaymentType).
              HasColumnType("varchar").
              HasMaxLength(20).IsRequired();

        builder.Property(i => i.Provider).
            HasColumnType("varchar")
            .HasMaxLength(20);

        builder.Property(i => i.AccountNumber).HasMaxLength(12).IsRequired();


        builder.Property(i => i.ExpireDate)
            .HasColumnType("date")
            .IsRequired();

        builder.HasOne(i => i.User)
       .WithMany(i => i.UserPayments)
       .HasForeignKey(i => i.UserId);
    }
}
