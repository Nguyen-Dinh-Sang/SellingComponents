using System;
using System.Collections.Generic;

#nullable disable

namespace WindowsForms.DataAccess.Entity
{
    public partial class Order
    {
        public Order()
        {
            OrdersDetails = new HashSet<OrdersDetail>();
        }

        public int Id { get; set; }
        public int IdUser { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal TotalCost { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime DeliveryDate { get; set; }

        public virtual UserInformation IdUserNavigation { get; set; }
        public virtual ICollection<OrdersDetail> OrdersDetails { get; set; }
    }
}
