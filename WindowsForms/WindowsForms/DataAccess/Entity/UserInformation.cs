using System;
using System.Collections.Generic;

#nullable disable

namespace WindowsForms.DataAccess.Entity
{
    public partial class UserInformation
    {
        public UserInformation()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Sex { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? Brithday { get; set; }
        public string Address { get; set; }
        public DateTime? JoinDate { get; set; }
        public int IdRole { get; set; }

        public virtual Role IdRoleNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
