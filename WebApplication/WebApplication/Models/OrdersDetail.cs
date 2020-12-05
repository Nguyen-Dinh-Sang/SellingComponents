using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication.Models
{
    public partial class OrdersDetail
    {
        public int Id { get; set; }
        public int IdOrders { get; set; }
        public int? IdCombo { get; set; }
        public int? IdProduct { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual Combo IdComboNavigation { get; set; }
        public virtual Order IdOrdersNavigation { get; set; }
        public virtual Product IdProductNavigation { get; set; }
    }
}
