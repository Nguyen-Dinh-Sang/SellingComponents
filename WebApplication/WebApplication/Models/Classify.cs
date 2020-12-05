using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication.Models
{
    public partial class Classify
    {
        public Classify()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string ClassifyName { get; set; }
        public string ClassifyDetail { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
