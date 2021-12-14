using System;
using System.Collections.Generic;
using System.Linq;
using WebSales.Domain.Models;
using WebSales.Shared.Entities;
using WebSales.Shared.Enums;

namespace WebSales.Domain.Entities
{
    public sealed class Sale : BaseEntity
    {
        private Sale() { }

        public Sale(int id, PaidBy paidBy, string creditCardNumber, string barCode, decimal amount, int userId, ICollection<SaleItems> saleItems) : base(id)
        {
            PaidBy = paidBy;
            CreditCardNumber = creditCardNumber;
            BarCode = barCode;
            Amount = amount;
            UserId = userId;
            SaleItems = saleItems;
        }

        public PaidBy PaidBy { get; private set; }
        public string CreditCardNumber { get; private set; }
        public string BarCode { get; private set; }
        public decimal Amount { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; }
        public ICollection<SaleItems> SaleItems { get; private set; }

        public void MergeProperties(Sale sale, SaleModel saleModel)
        {
            sale.PaidBy = saleModel.PaidBy;
            sale.CreditCardNumber = saleModel.CreditCardNumber;
            sale.BarCode = saleModel.BarCode;
            sale.Amount = saleModel.Amount;
            foreach (var saleItemsModel in saleModel.SaleItems)
            {
                var saleItem = sale.SaleItems.ToArray().FirstOrDefault(x => x.Id == saleItemsModel.Id);
                if (saleItem != null)
                    saleItem.MergeProperties(saleItem, saleItemsModel);
                else if (saleItemsModel.Id == 0)
                    sale.SaleItems.Add(new SaleItems(saleItemsModel.Id, saleItemsModel.Quantity, saleItemsModel.Price, saleItemsModel.ProductId));
            }
        }
    }
}
