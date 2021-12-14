using System;

namespace WebSales.Shared.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity() { }
        protected BaseEntity(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
        public DateTime InsertedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
    }
}
