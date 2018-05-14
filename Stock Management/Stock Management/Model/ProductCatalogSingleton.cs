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

        private ProductCatalogSingleton()
        {
            ProductList = new ObservableCollection<Product>();
            LoadProductsAsync();
            
        }

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
        #endregion

        #region Exeptions
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
            /*
            ProductList.Add(new Product(1,1, "Cola", 19.95m, Product.EnumStatus.AVAILABLE, 5, "Den er light", new Supplier(), 1, 5, DateTime.Now));
            ProductList.Add(new Product(1,2, "Vand", 32.95m, Product.EnumStatus.AVAILABLE, 2, "Vand uden brus", new Supplier(), 1, 5, DateTime.Now));
            ProductList.Add(new Product(1,3, "Samsung Galaxy s8", 2999.95m, Product.EnumStatus.AVAILABLE, 5, "Lækkert mobil fordi Benjamin har den.", new Supplier(), 1,5, DateTime.Now));
            ProductList.Add(new Product(1,4, "Lenovo Legion Y520", 7999.95m, Product.EnumStatus.AVAILABLE, 2,"lækkert PC", new Supplier(), 1,5,DateTime.Now));
            ProductList.Add(new Product(1,5, "Samsung Galaxy s9", 5000m, Product.EnumStatus.AVAILABLE, 3, "Nyeste i serien", new Supplier(), 1, 5, DateTime.Now));
            ProductList.Add(new Product(1,6, "Græsk Pony", 34999.95m, Product.EnumStatus.AVAILABLE, 2,"Flot hest, som minder om hakan<3",new Supplier(), 1,3,DateTime.Now));
            ProductList.Add(new Product(1,7, "Dildo", 999.95m, 2, "lækkert forlængerledning", new Supplier(), 1, 5, DateTime.Now));
            ProductList.Add(new Product(1,8, "Swordfish", 99.95m, 2, "Skulle smage godt", new Supplier(), 1, 5, DateTime.Now));
            ProductList.Add(new Product(1,9, "Gamer Stol fra SHABZ", 9999.95m, 2, Product.EnumStatus.AVAILABLE, "Det ikke en stol", 1, 5, DateTime.Now));
            ProductList.Add(new Product(1,10, "Mus", 7999.95m, 2, Product.EnumStatus.AVAILABLE, "Gamer mus fra MacDonald", 1, 5, DateTime.Now));
            ProductList.Add(new Product(1,11,"Lolita Søren", 9.95m, 4,Product.EnumStatus.AVAILABLE,"Hygge med Søren",1,5,DateTime.Now));
            */
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
        #endregion
    }
}
