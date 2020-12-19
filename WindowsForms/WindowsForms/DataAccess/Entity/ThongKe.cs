using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WindowsForms.DataAccess.Entity
{
    public class ThongKe
    {
        [DisplayName("Id Order")]

        public int Id { get; set; }
        [DisplayName("Id User")]

        public int IdUser { get; set; }
        [DisplayName("Tài Khoản")]

        public string UserName { get; set; }
        [DisplayName("Tên Khách Hàng")]

        public string FullName { get; set; }
        [DisplayName("Ngày Đặt")]

        public DateTime? OrderDate { get; set; }
        [DisplayName("Tổng Tiền")]

        public decimal TotalCost { get; set; }
        [DisplayName("Địa Chỉ Giao")]

        public string DeliveryAddress { get; set; }
        [DisplayName("Ngày Giao")]

        public DateTime DeliveryDate { get; set; }
    }
}
