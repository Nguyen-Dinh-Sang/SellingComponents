using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WindowsForms.Business.DTO
{
    public class CatalogDTO
    {
        public int Id { get; set; }
        [DisplayName("Tên Catalog")]
        public string CatalogName { get; set; }
        [DisplayName("Chi Tiết")]
        public string CatalogDetails { get; set; }
        [DisplayName("Ngày Tạo")]
        public DateTime? DateCreated { get; set; }
    }
}
