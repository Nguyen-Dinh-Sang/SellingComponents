using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WindowsForms.DataAccess.Entity
{
    public partial class Product
    {
        public Product()
        {
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
        public virtual ICollection<ComboDetail> ComboDetails { get; set; }
        public virtual ICollection<OrdersDetail> OrdersDetails { get; set; }
        public virtual ICollection<Warehouse> Warehouses { get; set; }
    }
}
