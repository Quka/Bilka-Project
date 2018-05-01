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
		ObservableCollection<Order> GetOrderList();
		void ApproveOrder(Order o);
		ObservableCollection<ProductReturn> GetProductReturnList();
	}
}
