using AuroraDAL;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class UserAddressConfiguration : IEntityTypeConfiguration<UserAddress>
{
    public void Configure(EntityTypeBuilder<UserAddress> builder)
    {
        builder.HasKey(i => i.Id);
        builder.Property(i => i.LineOne).
            HasColumnType("varchar").
            HasMaxLength(25).IsRequired();

        builder.Property(i => i.Id).ValueGeneratedOnAdd();

        builder.Property(i => i.LineTwo).
            HasColumnType("varchar")
            .HasMaxLength(25);

        builder.Property(i => i.Country).HasColumnType("varchar").HasMaxLength(25).IsRequired();
        builder.Property(i => i.City).HasColumnType("varchar").HasMaxLength(25).IsRequired();

        builder.HasOne(i => i.User)
       .WithMany(i => i.UserAddresses)
       .HasForeignKey(i => i.UserId);
    }
}
