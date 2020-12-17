using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WindowsForms.DataAccess.Context;
using WindowsForms.DataAccess.Entity;

namespace WindowsForms.DataAccess.Repository
{
    public class UserRepository
    {
        private SellingComponentsDBContext sellingComponentsDBContext = SellingComponentsDBContext.getInstance();

        private static UserRepository instance;

        private UserRepository()
        {
        }

        public static UserRepository getInstance()
        {
            if (instance == null)
            {
                instance = new UserRepository();
            }

            return instance;
        }

        public UserInformation login(string userName, string password)
        {
            var result = from m in sellingComponentsDBContext.UserInformations
                         where m.UserName == userName && m.Password == password && m.IdRole != 1
                         select m;
            return result.Count() > 0 ? result.First() : null;
        }
    }
}
