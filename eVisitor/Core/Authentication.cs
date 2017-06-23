using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eVisitor.Core
{
    public class Authentication
    {
        public String Username { private set; get; }
        public String Password { private set; get; }
        public Authentication(string username,string password)
        {
            this.Username = username;
            this.Password = password;
        }

       // public static Dictionary<string, string> LoginCookies = new Dictionary<string, string>();
    }
}
