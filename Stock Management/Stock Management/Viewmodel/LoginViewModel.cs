using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Stock_Management.Common;
using Stock_Management.Handler;
using Stock_Management.Model;

namespace Stock_Management.Viewmodel
{
    class LoginViewModel
    {
        private ICommand _loginCommand;

        public string Username { get; set; }
        public string Password { get; set; }
        public Employee Employee { get; set; }

	    public Handler.LoginHandler LoginHandler { get; set; }

        public ICommand LoginCommand
        {
            get { return _loginCommand ?? (_loginCommand = new RelayCommand(LoginHandler.Login)); }
            set { _loginCommand = value; }
        }

        public ICommand LogoutCommand { get; set; }

	    public LoginViewModel()
	    {
		    LoginHandler = new LoginHandler(this);
	    }
    }
}
