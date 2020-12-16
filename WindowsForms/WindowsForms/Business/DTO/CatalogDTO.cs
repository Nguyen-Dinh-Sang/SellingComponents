using System;
using System.Collections.Generic;
using System.Text;

namespace WindowsForms.Business.DTO
{
    public class CatalogDTO
    {
        public int Id { get; set; }
        public string CatalogName { get; set; }
        public string CatalogDetails { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
