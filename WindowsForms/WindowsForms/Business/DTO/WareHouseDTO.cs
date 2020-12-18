using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WindowsForms.Business.DTO
{
    public class WareHouseDTO
    {
        public int Id { get; set; }
        [DisplayName("Id Sản Phẩm")]
        public int IdProduct { get; set; }
        [DisplayName("Số Lượng")]
        public int Amount { get; set; }
        [DisplayName("Ngày Nhập")]
        public DateTime? InputDate { get; set; }
    }
}
