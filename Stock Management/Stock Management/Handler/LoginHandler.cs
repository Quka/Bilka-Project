using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock_Management.Model;
using Stock_Management.Viewmodel;

namespace Stock_Management.Handler
{
    class LoginHandler : ILoginHandler
    {
        public LoginViewModel LoginViewModel { get; set; }

	    public LoginHandler(LoginViewModel loginViewModel)
	    {
		    LoginViewModel = loginViewModel;
	    }

        public void Login()
        {
            string username = LoginViewModel.Username;
            string password = LoginViewModel.Password;

            Employee emp = new Employee(username, password); 
            
            LoginViewModel.LoginModel.AuthenticateLogin(emp);
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
