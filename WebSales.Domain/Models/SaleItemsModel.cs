namespace WebSales.Domain.Models
{
    public sealed class SaleItemsModel
    {
        public SaleItemsModel(int id, int quantity, decimal price, int productId, int saleId)
        {
            Id = id;
            Quantity = quantity;
            Price = price;
            ProductId = productId;
            SaleId = saleId;
        }

        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public int SaleId { get; set; }
    }
}
