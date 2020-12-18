using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication.Models
{
    public partial class Product
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
            ComboDetails = new HashSet<ComboDetail>();
            OrdersDetails = new HashSet<OrdersDetail>();
            Warehouses = new HashSet<Warehouse>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public int? Amount { get; set; }
        public decimal Price { get; set; }
        public string Detail { get; set; }
        public int IdClassify { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual Classify IdClassifyNavigation { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<ComboDetail> ComboDetails { get; set; }
        public virtual ICollection<OrdersDetail> OrdersDetails { get; set; }
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
