using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock_Management.Model.Interface;
using Stock_Management.Persistency;

namespace Stock_Management.Model
{
    public class Product : IProduct
	{
		public int Id { get; set; }
		public int SupplierId { get; set; }
        public int ItemNr { get; set; }
	    public string Name { get; set; }
		public decimal Price { get; set; }
		public int Stock { get; set; }
        public string Description { get; set; }
	    public int MinStock { get; set; }
	    public int RestockAmount { get; set; }
	    public DateTime RestockPeriod { get; set; }
		public Supplier Supplier { get; set; }
        public String Satus { get; set; }
        public ObservableCollection<Order> OrderList { get; set; }
		public ObservableCollection<ProductReturn> ProductReturns { get; set; }

		public Product()
		{
			// Overload with empty constructor
		}
        public Product(int supplierId, int itemNr, string name, decimal price, int stock, string status, string description, int minStock, int restockAmount, DateTime restockPeriod)
        {
	        SupplierId = supplierId;
			ItemNr = itemNr;
			Name = name;
			Price = price;
			Stock = stock;

			Description = description;
			MinStock  = minStock;
			RestockAmount = restockAmount;
			RestockPeriod = restockPeriod;
        }

		public void ApproveOrder(Order o)
		{
			throw new NotImplementedException();
		}

		public override string ToString()
	    {
		    return Name;
	    }

		public void CreateProductReturn(ProductReturn productReturn)
		{
			throw new NotImplementedException();
		}

		public void FillOrderList(List<Order> orderList)
		{
			OrderList = new ObservableCollection<Order>();

			if (orderList != null || orderList.Count > 0)
			{
				// Fill the ObservableCollection<Order> in current Product with the orders
				foreach (Order order in orderList)
				{
					OrderList.Add(order);
				}
			}
			else
			{
				throw new ArgumentNullException("'orderList' passed to Product is null");
			}
		}

		public void FillProductReturnList(List<ProductReturn> productReturnList)
		{
			ProductReturns = new ObservableCollection<ProductReturn>();

			if (productReturnList != null || productReturnList.Count <= 0)
			{
				// Fill the ObservableCollection<Order> in current Product with the orders
				foreach (ProductReturn productReturn in productReturnList)
				{
					ProductReturns.Add(productReturn);
				}
			}
			else
			{
				throw new ArgumentNullException("'productReturnList' passed to Product is null or empty");
			}
		}
	}
}
