using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Store;
using Stock_Management.Model.Interface;
using Stock_Management.Persistency;

namespace Stock_Management.Model
{
    class ProductCatalogSingleton : IProductCatalogSingleton
    {
        private static ProductCatalogSingleton _instance;
        public static ProductCatalogSingleton Instance
        {
            get { return _instance ?? (_instance = new ProductCatalogSingleton()); }
        }

        public ObservableCollection<Product> ProductList { get; set; }
        public ObservableCollection<Supplier> SupplierList { get; set; }
        
        private ProductCatalogSingleton()
        {
            ProductList = new ObservableCollection<Product>();
            LoadProductsAsync();

            SupplierList  = new ObservableCollection<Supplier>();
            LoadSuppliersAsync();

        }

        public void CreateProduct(Product p)
        {
	        if (p.Supplier == null)
	        {
				// Supplier or any of suppliers properties are null
				throw new ArgumentNullException();
	        }

	        try
	        {
				// Add in DB1   
		        PersistencyService.InsertProductAsync(p);

				// Add to ProductList
		        ProductList.Add(p);
			}
	        catch (Exception e)
	        {
		        Debug.WriteLine(e);
	        }
        }

        public void DeleteProduct(Product p)
        {
	        try
	        {
				// Remove from DB
		        PersistencyService.DeleteProductAsync(p);

				// Remove from List
		        ProductList.Remove(p);
			}
	        catch (Exception e)
	        {
		        Debug.WriteLine(e);
	        }
		}
        public void UpdateProduct(Product p)
        {
			// TODO update product in the ProductCatalogSingleton list as well

	        // Update product in DB
	        PersistencyService.UpdateProductAsync(p);
		}
		
        public Product FindSpecificProduct(int x)
        {
            throw new NotImplementedException();
        }

        public List<Product> FindProducts(string s)
        {
            throw new NotImplementedException();
        }

        public void OrderProduct(Product p, int amount)
        {
			// Create an order 
			
			// Sets datetime variable for date and estDelivery. As DateTime can't be null so we set
			// the property to the same thing. If they are the same, that means estDilevery has not been set
	        DateTime now = DateTime.Now;

	        // EnumStatus: I am using the built in EnumStatus' and do a toString on them as the DB takes a string
			Order o = new Order(p.Id, p.SupplierId, Order.EnumStatus.PENDING.ToString(), amount, now, now );

			// Insert order
	        PersistencyService.InsertOrder(o);
        }

	    public async Task LoadProductsAsync()
	    {
		    try
		    {
			    List<Product> products = await PersistencyService.LoadProductsAsync();
			    foreach (Product p in products)
			    {
				    ProductList.Add(p);
			    }
		    }
		    catch (Exception e)
		    {
			    Debug.WriteLine(e);
			    throw;
		    }
	    }

		public async Task LoadSuppliersAsync()
        {
			/*
            SupplierList.Add(new Supplier("Benjamin Kakar", "Lyndmosen 21", "Benjamin@live.dk", "60633636"));
            SupplierList.Add(new Supplier("Benjamin Kakar", "Lyndmosen 21", "Benjamin@live.dk", "60633636"));
            SupplierList.Add(new Supplier("Benjamin Kakar", "Lyndmosen 21", "Benjamin@live.dk", "60633636"));
            SupplierList.Add(new Supplier("Benjamin Kakar", "Lyndmosen 21", "Benjamin@live.dk", "60633636"));
            SupplierList.Add(new Supplier("Benjamin Kakar", "Lyndmosen 21", "Benjamin@live.dk", "60633636"));
            SupplierList.Add(new Supplier("Benjamin Kakar", "Lyndmosen 21", "Benjamin@live.dk", "60633636"));
            SupplierList.Add(new Supplier("Benjamin Kakar", "Lyndmosen 21", "Benjamin@live.dk", "60633636"));
			*/

	        try
	        {
		        List<Supplier> suppliers = await PersistencyService.LoadSuppliersAsync();
		        foreach (Supplier supplier in suppliers)
		        {
			        SupplierList.Add(supplier);
		        }
			}
	        catch (Exception e)
	        {
		        Debug.WriteLine(e);
		        throw;
	        }
        }

		public void CreateSupplier(Supplier s)
		{
			PersistencyService.InsertSupplier(s);
		}
	}
}