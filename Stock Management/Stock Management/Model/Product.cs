using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock_Management.Model.Interface;

namespace Stock_Management.Model
{
    public class Product : IProduct
	{
	    public ObservableCollection<Order> GetOrderList()
	    {
	        throw new NotImplementedException();
	    }

	    public void ApproveOrder(Order o)
	    {
	        throw new NotImplementedException();
	    }

	    public ObservableCollection<ProductReturn> GetProductReturnList()
	    {
	        throw new NotImplementedException();
	    }
	}
}
