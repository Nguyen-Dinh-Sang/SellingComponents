using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WindowsForms.Business.DTO
{
    public class ComboDTO
    {
        public int Id { get; set; }
        [DisplayName("Tên Combo")]
        public string ComboName { get; set; }
        [DisplayName("Chi Tiết")]
        public string ComboDetails { get; set; }
        [DisplayName("Tổng Tiền")]
        public decimal TotalCost { get; set; }
        [DisplayName("Giá Bán")]
        public decimal Price { get; set; }
        [DisplayName("Id Catalog")]
        public int IdCatalog { get; set; }
        [DisplayName("Ngày Tạo")]
        public DateTime? DateCreated { get; set; }
    }
}
