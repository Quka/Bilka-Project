using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock_Management.Model.Interface;

namespace Stock_Management.Model
{
    public class Employee : IEmployee
	{
	    public int Id { get; set; }

		public string SalNo { get; set; }

	    public string Name { get; set; }

	    public string Password { get; set; }

	}
}
