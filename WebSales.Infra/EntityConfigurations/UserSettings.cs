using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebSales.Domain.Entities;

namespace WebSales.Infra.EntityConfigurations
{
    public class UserSettings : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User)).HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.UserName).HasMaxLength(20).IsRequired();
            builder.Property(x => x.PassWord).HasMaxLength(45).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Gender).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(15);
            builder.Property(x => x.Address).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(50);
        }
    }
}
