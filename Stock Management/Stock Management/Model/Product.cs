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
		/*
		 public enum EnumStatus
		{
			AVAILABLE,
			SOLDOUT
		}
		public EnumStatus Status { get; set; }
        */
	    public string Status { get; set; }
	    public string Description { get; set; }
	    public int MinStock { get; set; }
	    public int RestockAmount { get; set; }
	    public DateTime RestockPeriod { get; set; }
		public Supplier Supplier { get; set; }
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
	        Status = status;
			Description = description;
			MinStock  = minStock;
			RestockAmount = restockAmount;
			RestockPeriod = restockPeriod;
		}
        
	    public async void GetOrderList()
	    {
		    try
		    {
			    List<Order> Orders = await PersistencyService.LoadOrdersAsync();

			    foreach (Order order in Orders)
			    {
				    OrderList.Add(order);
			    }
			}
		    catch (Exception e)
		    {
			    Debug.WriteLine(e);
			    throw;
		    }
	    }

        public void ApproveOrder(Order o)
        {
            throw new NotImplementedException();
        }

	    public void GetProductReturnList()
	    {
	        throw new NotImplementedException();
	    }

	    public override string ToString()
	    {
	        return $"{nameof(ItemNr)}: {ItemNr}, {nameof(Name)}: {Name}, {nameof(Price)}: {Price}, {nameof(Stock)}: {Stock}, {nameof(Description)}: {Description}, {nameof(Supplier)}: {Supplier}, {nameof(MinStock)}: {MinStock}, {nameof(RestockAmount)}: {RestockAmount}, {nameof(RestockPeriod)}: {RestockPeriod}";
	    }
	}
}
