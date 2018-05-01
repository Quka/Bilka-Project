using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock_Management.Model.Interface;

namespace Stock_Management.Model
{
    public class Order : IOrder
	{
	    public Product Product { get; set; }

	    public int Amount { get; set; }

	    public Supplier Supplier { get; set; }

      // TODO Add types to the enum.
	    public enum Status { } 

	    public DateTime DateTime { get; set; }

	    public DateTime EstDelivery { get; set; }

	    public bool IsApproved { get; set; }

	}
}
