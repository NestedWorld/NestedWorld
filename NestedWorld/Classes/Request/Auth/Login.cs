using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedWorld.Classes.Request.Auth
{
    public class Login : HttpRequest
    {
        public Login()
            : base("/users/auth/login/simple", RequestType.POST)
        { }

        public void SetParam(string password, string mail)
        {

            collection = new Dictionary<string, string>();
            collection.Add("password", password);
            collection.Add("email", mail);
         
            uri = new Uri(url);
        }
    }
}
