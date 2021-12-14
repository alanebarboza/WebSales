using WebSales.Domain.Models;
using WebSales.Shared.Entities;

namespace WebSales.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        public Product(int id, string name, string description, decimal price, int stock) : base(id)
        {
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }

        public void MergeProperties(Product product, ProductModel productModel)
        {
            product.Name = productModel.Name;   
            product.Description = productModel.Description; 
            product.Price = productModel.Price;
            product.Stock = productModel.Stock;
        }

    }
}
