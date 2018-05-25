using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Stock_Management.Model.Interface;
using Stock_Management.Persistency;

namespace Stock_Management.Model
{
    class LoginModel : ILoginModel
    {
        public async Task AuthenticateLogin(Employee employee)
        {
            try
            {
                List<Employee> employees = await PersistencyService.LoadEmployeesAsync();

                new MessageDialog(employees.ToString()).ShowAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }
    }
}
