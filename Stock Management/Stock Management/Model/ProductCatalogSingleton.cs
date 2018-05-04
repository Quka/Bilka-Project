using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock_Management.Model.Interface;
using Stock_Management.Viewmodel;

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
        public ObservableCollection<Product> ProductList;

        private ProductCatalogSingleton()
        {
            ProductList = new ObservableCollection<Product>();
            
        }

        
        #endregion

        

        #region Exeptions
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

        public ObservableCollection<Product> LoadProductsAsync()
        {
            throw new NotImplementedException();
        }

        public void OrderProduct(Product p, int amount)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
