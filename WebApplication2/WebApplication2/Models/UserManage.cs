using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class UserManage
    {
        Model1 db = new Model1();
        public bool CheckEmail (string email)
        {
            List<User> users_finded = (from nd in db.Users where nd.Email == email select nd).ToList();
            if (users_finded.Count == 1)
            {
                return true;
            }
            else { return false; }
        }
        public bool CheckAccount(string account)
        {
            List<User> users_finded = (from nd in db.Users where nd.Account == account select nd).ToList();
            if (users_finded.Count == 1)
            {
                return true;
            }
            else { return false; }
        }
    }
    public class LoginManage
    {
        Model1 db = new Model1();
        public bool CheckAccount(string account)
        {
            List<User> users_finded = (from nd in db.Users where nd.Account == account select nd).ToList();
            if (users_finded.Count == 1)
            {
                return true;
            }
            else { return false; }
        }
        public bool CheckPassword(string password)
        {
            List<User> users_finded = (from nd in db.Users where nd.Password == password select nd).ToList();
            if (users_finded.Count == 1)
            {
                return true;
            }
            else { return false; }
        }
    }
}