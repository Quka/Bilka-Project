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
        #region Properties
        public int ItemNr { get; set; }
	    public string Name { get; set; }
	    public decimal Price { get; set; }
	    public int Stock { get; set; }
	    //TODO Add enum types
        public enum Status { }
	    public string Description { get; set; }
	    public Supplier Supplier { get; set; }
	    public int MinStock { get; set; }
	    public int RestockAmount { get; set; }
	    public DateTime RestockPeriod { get; set; }
        #endregion

	    #region Constructor
        public Product(int itemNr, string name, decimal price, int stock, string description, Supplier supplier, int minStock, int restockAmount, DateTime restockPeriod)
		{
			ItemNr = itemNr;
			Name = name;
			Price = price;
			Stock = stock;
			Description = description;
			Supplier = supplier;
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

	    public override string ToString()
	    {
	        return $"{nameof(ItemNr)}: {ItemNr}, {nameof(Name)}: {Name}, {nameof(Price)}: {Price}, {nameof(Stock)}: {Stock}, {nameof(Description)}: {Description}, {nameof(Supplier)}: {Supplier}, {nameof(MinStock)}: {MinStock}, {nameof(RestockAmount)}: {RestockAmount}, {nameof(RestockPeriod)}: {RestockPeriod}";
	    }
	}
}
