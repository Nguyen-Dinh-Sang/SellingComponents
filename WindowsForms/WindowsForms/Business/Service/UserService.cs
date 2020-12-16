using System;
using System.Collections.Generic;
using System.Text;
using WindowsForms.DataAccess.Entity;
using WindowsForms.DataAccess.Repository;

namespace WindowsForms.Business.Service
{
    public class UserService
    {
        private UserRepository userRepository = UserRepository.getInstance();

        private static UserService instance;

        private UserService()
        {

        }

        public static UserService getInstance()
        {
            if (instance == null)
            {
                instance = new UserService();
            }

            return instance;
        }

        public Boolean checkLogin(string userName, string password)
        {
            if (userRepository.login(userName, password) != null)
            {
                return true;
            }
            return false;
        }
    }
}
