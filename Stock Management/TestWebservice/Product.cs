using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementWS;

namespace Stock_Management.Model
{
	public class Product
	{
		public int Id { get; set; }
		public int SupplierId { get; set; }
		public int ItemNr { get; set; }
		public string Name { get; set; }
		public decimal Price { get; set; }
		public int Stock { get; set; }
		//TODO Add enum types
		public string Status { get; set; }
		public string Description { get; set; }
		public int MinStock { get; set; }
		public int RestockAmount { get; set; }
		public DateTime RestockPeriod { get; set; }
		public ObservableCollection<Order> OrderList { get; set; }
		public ObservableCollection<ProductReturn> ProductReturnList { get; set; }
		public Supplier Supplier { get; set; }

		public Product(int supplierId, int itemNr, string name, decimal price, int stock, string status, string description, int minStock, int restockAmount, DateTime restockPeriod)
		{
			SupplierId = supplierId;
			ItemNr = itemNr;
			Name = name;
			Price = price;
			Stock = stock;
			Status = status;
			Description = description;
			MinStock = minStock;
			RestockAmount = restockAmount;
			RestockPeriod = restockPeriod;
		}

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
