using WebSales.Domain.Models;
using WebSales.Shared.Entities;

namespace WebSales.Domain.Entities
{
    public sealed class SaleItems : BaseEntity
    {
        public SaleItems(int id, int quantity, decimal price, int productId) : base(id)
        {
            Quantity = quantity;
            Price = price;
            ProductId = productId;
        }

        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public int ProductId { get; private set; }
        public Product Product { get; private set; }
        public int SaleId { get; private set; }
        public Sale Sale { get; private set; }

        public void MergeProperties(SaleItems saleItems, SaleItemsModel saleItemsModel)
        {
            saleItems.Quantity = saleItemsModel.Quantity;
            saleItems.Price = saleItemsModel.Price;
        }
    }
}
