using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace admin
{
    internal class User
    {
        private string pass;
        private string users;
        private bool admin = false;

        public User(string users, string pass, bool IsAdmin)
        {
            this.pass = pass;
            this.users = users;
            this.admin = IsAdmin;
        }
        public string UserName
        {
            get { return users; }
        }
        public string Password
        {
            get { return pass; }
        }
        public bool IsAdmin()
        {
            return admin;
        }
    }
}
