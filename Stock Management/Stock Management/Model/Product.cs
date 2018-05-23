﻿using System;
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



        #region Status
        public enum EnumStatus
		{
			AVAILABLE,
			UNAVAILIBLE,
            ORDERED
		}

        //private EnumStatus enumStatus;

        //public void SetEnumStatus(EnumStatus value)
        //{
        //    enumStatus = value;
        //}

        //public EnumStatus GetEnumStatus()
        //{
        //    return enumStatus;
        //}

        public  String GetString( this EnumStatus Status)
        {

            switch (Status)
            {
                case EnumStatus.AVAILABLE:
                    return "På Lager";
                case EnumStatus.UNAVAILIBLE:
                    return "Udsolgt";
                case EnumStatus.ORDERED:
                    return "Bestilt";
                default:
                    return "Ingen status";
            }

        }

        //public EnumStatus Status { get; set; }
        #endregion

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
		    return Name;
	    }
	}
}
