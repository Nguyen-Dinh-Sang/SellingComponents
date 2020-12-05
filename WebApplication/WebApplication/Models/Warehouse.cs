using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication.Models
{
    public partial class Warehouse
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int Amount { get; set; }
        public DateTime? InputDate { get; set; }

        public virtual Product IdProductNavigation { get; set; }
    }
}
