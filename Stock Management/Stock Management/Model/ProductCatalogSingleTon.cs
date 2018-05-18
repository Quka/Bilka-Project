using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            ProductList.Add(p);
	        PersistencyService.InsertProductAsync(p);
        }
        public void DeleteProduct(Product p)
        {
            ProductList.Remove(p);
       //     LoadProductsAsync().Remove(p);
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
            throw new NotImplementedException();
        }

        private async void LoadSuppliersAsync()
        {
            SupplierList.Add(new Supplier("Benjamin Kakar", "Lyndmosen 21", "Benjamin@live.dk", "60633636"));
            SupplierList.Add(new Supplier("Benjamin Kakar", "Lyndmosen 21", "Benjamin@live.dk", "60633636"));
            SupplierList.Add(new Supplier("Benjamin Kakar", "Lyndmosen 21", "Benjamin@live.dk", "60633636"));
            SupplierList.Add(new Supplier("Benjamin Kakar", "Lyndmosen 21", "Benjamin@live.dk", "60633636"));
            SupplierList.Add(new Supplier("Benjamin Kakar", "Lyndmosen 21", "Benjamin@live.dk", "60633636"));
            SupplierList.Add(new Supplier("Benjamin Kakar", "Lyndmosen 21", "Benjamin@live.dk", "60633636"));
            SupplierList.Add(new Supplier("Benjamin Kakar", "Lyndmosen 21", "Benjamin@live.dk", "60633636"));
            //var suppliers = await PersistencyService.LoadSuppliersAsync();

        }

    }
}
