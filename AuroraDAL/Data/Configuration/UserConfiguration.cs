using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuroraDAL;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(i => i.Fname).HasColumnType("varchar")
            .HasMaxLength(25);

        builder.Property(i => i.Lname).HasColumnType("varchar")
         .HasMaxLength(25);

    }
}
