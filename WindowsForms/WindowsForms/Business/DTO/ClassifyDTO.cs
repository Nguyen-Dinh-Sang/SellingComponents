using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WindowsForms.Business.DTO
{
    public class ClassifyDTO
    {
        public int Id { get; set; }
        [DisplayName("Loại")]
        public string ClassifyName { get; set; }
        [DisplayName("Chi Tiết")]
        public string ClassifyDetail { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
