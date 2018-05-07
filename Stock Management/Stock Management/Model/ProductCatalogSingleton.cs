using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Appointments.AppointmentsProvider;
using Stock_Management.Model.Interface;

namespace Stock_Management.Model
{
    public class ProductCatalogSingleton : IProductCatalogSingleton
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
            throw new NotImplementedException();
        }

        public void DeleteProduct(Product p)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product p)
        {
            throw new NotImplementedException();
        }

        public Product FindSpecificProduct(int i)
        {
            throw new NotImplementedException();
        }

        public List<Product> FindProducts(string s)
        {
            throw new NotImplementedException();
        }

        // TODO Add async later :)
        public void LoadProductsAsync()
        {
            ProductList.Add(new Product(1, "Cola", 19.95m, 5, "Den er light", new Supplier(), 1, 5, DateTime.Now));
            ProductList.Add(new Product(2, "Cola2", 19.95m, 5, "Den er light", new Supplier(), 1, 5, DateTime.Now));

            ProductList.Add(new Product(3, "Cola2", 19.95m, 5, "Den er light", new Supplier(), 1, 5, DateTime.Now));
            ProductList.Add(new Product(4, "Cola2", 19.95m, 5, "Den er light", new Supplier(), 1, 5, DateTime.Now));
        }   

        public void OrderProduct(Product p, int amount)
        {
            throw new NotImplementedException();
        }
    }
}
