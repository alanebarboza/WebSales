using System;
using System.Collections.Generic;
using WebSales.Shared.Enums;

namespace WebSales.Domain.Models
{
    public sealed class SaleModel
    {
        public SaleModel(int id, PaidBy paidBy, string creditCardNumber, string barCode, decimal amount, int userId, ICollection<SaleItemsModel> saleItems)
        {
            Id = id;
            PaidBy = paidBy;
            CreditCardNumber = creditCardNumber;
            BarCode = barCode;
            Amount = amount;
            UserId = userId;
            SaleItems = saleItems;
        }

        public int Id { get; set; }
        public PaidBy PaidBy { get; set; }
        public string CreditCardNumber { get; set; }
        public string BarCode { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
        public ICollection<SaleItemsModel> SaleItems { get; set; }
    }
}
