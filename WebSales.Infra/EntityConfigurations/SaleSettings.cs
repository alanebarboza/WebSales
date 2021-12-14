using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebSales.Domain.Entities;

namespace WebSales.Infra.EntityConfigurations
{
    public class SaleSettings : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable(nameof(Sale)).HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.PaidBy).IsRequired();
            builder.Property(x => x.CreditCardNumber).HasMaxLength(16);
            builder.Property(x => x.BarCode).HasMaxLength(43);

            builder.HasOne(x => x.User).WithMany();
        }
    }
}