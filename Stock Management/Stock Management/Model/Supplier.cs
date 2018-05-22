using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Stock_Management.Model.Interface;

namespace Stock_Management.Model
{
    public class Supplier : ISupplier, INotifyPropertyChanged
	{
	    public string Name { get; set; }

	    public string Address { get; set; }

	    public string Email { get; set; }
		
	    public string Phone { get; set; }

	    public Supplier(string name, string address, string email, string phone)
	    {
	        Name = name;
	        Address = address;
	        Email = email;
	        Phone = phone;
	    }

	    public override string ToString()
	    {
	        return Name;
	    }

	    public event PropertyChangedEventHandler PropertyChanged;

	    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
	    {
	        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	    }
	}

}
