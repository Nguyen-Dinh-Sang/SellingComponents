using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WindowsForms.Business.DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [DisplayName("Tên Sản Phẩm")]
        public string ProductName { get; set; }
        [DisplayName("Số Lượng")]
        public int? Amount { get; set; }
        [DisplayName("Giá")]
        public decimal Price { get; set; }
        [DisplayName("Chi Tiết")]
        public string Detail { get; set; }
        [DisplayName("Loại Id")]
        public int IdClassify { get; set; }
        [DisplayName("Ngày Tạo")]
        public DateTime? DateCreated { get; set; }
    }
}
