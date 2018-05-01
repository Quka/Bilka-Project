using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock_Management.Model.Interface;

namespace Stock_Management.Model
{
    public class Supplier : ISupplier
	{
	    public string Name { get; set; }

	    public string Address { get; set; }

	    public string Email { get; set; }

        //  Are we sure this should be a string and not an int? - Søren
	    public string Phone { get; set; }
	}
}
