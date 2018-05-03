using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Stock_Management.Model;

namespace Stock_Management.Viewmodel
{
    class LoginViewModel
    {
        public Employee Employee { get; set; }
        public LoginModel LoginModel { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
    }
}
