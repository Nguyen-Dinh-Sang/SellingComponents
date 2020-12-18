using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication.Models
{
    public partial class Cart
    {
        public int Id { get; set; }
        public int? IdCombo { get; set; }
        public int? IdProduct { get; set; }
        public int? IdUser { get; set; }
        public int Amount { get; set; }
        public virtual Combo IdComboNavigation { get; set; }
        public virtual Product IdProductNavigation { get; set; }
        public virtual UserInformation IdUserNavigation { get; set; }
    }
}
