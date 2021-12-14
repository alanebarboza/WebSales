using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebSales.Domain.Entities;

namespace WebSales.Infra.EntityConfigurations
{
    public class SaleItemsSettings : IEntityTypeConfiguration<SaleItems>
    {
        public void Configure(EntityTypeBuilder<SaleItems> builder)
        {
            builder.ToTable(nameof(SaleItems)).HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Price).IsRequired();

            builder.HasOne(x => x.Product).WithMany();
            builder.HasOne(x => x.Sale).WithMany();
            builder.HasOne(x => x.Sale).WithMany(x => x.SaleItems).OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}