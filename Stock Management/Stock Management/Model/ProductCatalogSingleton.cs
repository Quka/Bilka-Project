using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Store;
using Stock_Management.Model.Interface;
using Stock_Management.PersistencyService;

namespace Stock_Management.Model
{
    class ProductCatalogSingleton : IProductCatalogSingleton
    {
        #region Singleton
        private static ProductCatalogSingleton _instance;
        public static ProductCatalogSingleton Instance
        {
            get { return _instance ?? (_instance = new ProductCatalogSingleton()); }
        }
        #endregion

        #region Observable Collection
        public ObservableCollection<Product> ProductList { get; set; }

        private ProductCatalogSingleton()
        {
            ProductList = new ObservableCollection<Product>();
            LoadProductsAsync();
            
        }

        
        #endregion

        public void CreateProduct(Product p)
        {
            ProductList.Add(p);
        //   PersistencyService.InsertProductAsync(ProductList);
        }
        public void DeleteProduct(Product p)
        {
            ProductList.Remove(p);
       //     LoadProductsAsync().Remove(p);
        }
        public void UpdateProduct(Product p)
        {
            //p.Description
        }

        public Product FindSpecificProduct(int x)
        {
            throw new NotImplementedException();
        }

        public List<Product> FindProducts(string s)
        {
            throw new NotImplementedException();
        }

        public void LoadProductsAsync()
        {
            ProductList.Add(new Product(1, "Cola", 19.95m, 5, "Den er light", new Supplier(), 1, 5, DateTime.Now));
            ProductList.Add(new Product(2, "Vand", 32.95m, 2, "Vand uden brus", new Supplier(), 1, 5, DateTime.Now));
            ProductList.Add(new Product(3, "Samsung Galaxy s8", 2999.95m, 5, "Lækkert mobil fordi Benjamin har den.", new Supplier(), 1,5, DateTime.Now));
            ProductList.Add(new Product(4, "Lenovo Legion Y520", 7999.95m, 2,"lækkert PC", new Supplier(), 1,5,DateTime.Now));
            ProductList.Add(new Product(5, "Samsung Galaxy s9", 5000m, 3, "Nyeste i serien", new Supplier(), 1, 5, DateTime.Now));
            ProductList.Add(new Product(6, "Græsk Pony", 34999.95m, 2,"Flot hest, som minder om hakan<3",new Supplier(), 1,3,DateTime.Now));
            ProductList.Add(new Product(7, "Dildo", 999.95m, 2, "lækkert forlængerledning", new Supplier(), 1, 5, DateTime.Now));
            ProductList.Add(new Product(8, "Swordfish", 99.95m, 2, "Skulle smage godt", new Supplier(), 1, 5, DateTime.Now));
            ProductList.Add(new Product(9, "Gamer Stol fra SHABZ", 9999.95m, 2, "Det ikke en stol", new Supplier(), 1, 5, DateTime.Now));
            ProductList.Add(new Product(10, "Mus", 7999.95m, 2, "Gamer mus fra MacDonald", new Supplier(), 1, 5, DateTime.Now));
        }

        public void OrderProduct(Product p, int amount)
        {
            throw new NotImplementedException();
        }
      
    }
}
