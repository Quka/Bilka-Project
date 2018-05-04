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
        }
        #endregion

        public void CreateProduct(Product p)
        {
            ProductList.Add(p);
            PersistencyService.InsertProductAsync(ProductList);
        }
        public void DeleteProduct(Product p)
        {
            ProductList.Remove(p);
            LoadProductsAsync().Remove(p);
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

        public ObservableCollection<Product> LoadProductsAsync()
        {
            throw new NotImplementedException();
        }

        public void OrderProduct(Product p, int amount)
        {
            throw new NotImplementedException();
        }
      
    }
}
