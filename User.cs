using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authorization
{
    internal class User
    {
        public string UserName;
        public string gender;
        public string login;
        public string password;

        public User(String login, String password, string userName, string gender)
        {
            this.login = login;
            this.password = password;
            UserName = userName;
            this.gender = gender;
        }
    }
}
