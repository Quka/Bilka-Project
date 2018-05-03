using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock_Management.Viewmodel;

namespace Stock_Management.Handler
{
    class LoginHandler : ILoginHandler
    {
        public LoginViewModel LoginViewModel { get; set; }

        public void Login()
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
