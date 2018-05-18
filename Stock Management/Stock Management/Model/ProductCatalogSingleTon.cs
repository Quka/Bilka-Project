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

        private ProductCatalogSingleton()
        {
            ProductList = new ObservableCollection<Product>();
            LoadProductsAsync();
            
        }

        public void CreateProduct(Product p)
        {
	        //decimal pPrice = Decimal.Parse(p.Price);
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

        public async void LoadProductsAsync()
        {
            var products = await PersistencyService.LoadProductsAsync();
            foreach (Product p in products)
            {
                ProductList.Add(p);
            }
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
      
    }
}
