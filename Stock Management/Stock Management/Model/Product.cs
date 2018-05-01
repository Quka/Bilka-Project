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
	    public int ItemNr { get; set; }
	    public string Name { get; set; }
	    public double Price { get; set; }
	    public int Stock { get; set; }
	    //TODO Add enum types
        public enum Status { }

	    public string Description { get; set; }
	    public Supplier Supplier { get; set; }
	    public int MinStock { get; set; }
	    public int RestockAmount { get; set; }
	    public DateTime RestockPeriod { get; set; }
	    public ObservableCollection<Order> OrderList { get; set; }
	    public ObservableCollection<ProductReturn> ProductReturnList { get; set; }

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
