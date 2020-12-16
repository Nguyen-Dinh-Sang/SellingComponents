using System;
using System.Collections.Generic;

#nullable disable

namespace WindowsForms.DataAccess.Entity
{
    public partial class Combo
    {
        public Combo()
        {
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
        public virtual ICollection<ComboDetail> ComboDetailsNavigation { get; set; }
        public virtual ICollection<OrdersDetail> OrdersDetails { get; set; }
    }
}
