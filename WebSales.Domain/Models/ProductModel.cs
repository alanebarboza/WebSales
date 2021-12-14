﻿using System;

namespace WebSales.Domain.Models
{
    public sealed class ProductModel
    {
        public ProductModel(int id, string name, string description, decimal price, int stock)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
