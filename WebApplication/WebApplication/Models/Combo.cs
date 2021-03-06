﻿using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication.Models
{
    public partial class Combo
    {
        public Combo()
        {
            Carts = new HashSet<Cart>();
            ComboDetailsNavigation = new HashSet<ComboDetail>();
            OrdersDetails = new HashSet<OrdersDetail>();
        }

        public int Id { get; set; }
        public string ComboName { get; set; }
        public string ComboDetails { get; set; }
        public decimal TotalCost { get; set; }
        public decimal Price { get; set; }
        public int IdCatalog { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual Catalog IdCatalogNavigation { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<ComboDetail> ComboDetailsNavigation { get; set; }
        public virtual ICollection<OrdersDetail> OrdersDetails { get; set; }
    }
}
