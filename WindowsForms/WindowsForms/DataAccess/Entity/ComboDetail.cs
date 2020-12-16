using System;
using System.Collections.Generic;

#nullable disable

namespace WindowsForms.DataAccess.Entity
{
    public partial class ComboDetail
    {
        public int Id { get; set; }
        public int IdCombo { get; set; }
        public int IdProduct { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual Combo IdComboNavigation { get; set; }
        public virtual Product IdProductNavigation { get; set; }
    }
}
