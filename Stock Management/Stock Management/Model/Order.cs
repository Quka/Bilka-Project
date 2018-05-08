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
		public int Id { get; set; }
		public int ProductId { get; set; }
		public int SupplierId { get; set; }

		public enum EnumStatus
		{
			PENDING,
			RECEIVED,
			CONFIRMED
		}
		public EnumStatus Status { get; set; }
		public int Amount { get; set; }
		public DateTime Date { get; set; }
		public DateTime EstDelivery { get; set; }
		public bool Approved { get; set; }

		public Product Product { get; set; }

	    

	    public Supplier Supplier { get; set; }
		

		

	    

	    

	}
}
