using System;
using System.Collections.Generic;

#nullable disable

namespace WindowsForms.DataAccess.Entity
{
    public partial class Role
    {
        public Role()
        {
            UserInformations = new HashSet<UserInformation>();
        }

        public int Id { get; set; }
        public string Role1 { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual ICollection<UserInformation> UserInformations { get; set; }
    }
}
