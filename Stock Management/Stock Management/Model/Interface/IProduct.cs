using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Management.Model.Interface
{
	interface IProduct
	{
		void GetOrderList();
		void ApproveOrder(Order o);
		void GetProductReturnList();
	}
}
