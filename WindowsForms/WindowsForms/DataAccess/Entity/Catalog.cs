using System;
using System.Collections.Generic;

#nullable disable

namespace WindowsForms.DataAccess.Entity
{
    public partial class Catalog
    {
        public Catalog()
        {
            Combos = new HashSet<Combo>();
        }

        public int Id { get; set; }
        public string CatalogName { get; set; }
        public string CatalogDetails { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual ICollection<Combo> Combos { get; set; }
    }
}
