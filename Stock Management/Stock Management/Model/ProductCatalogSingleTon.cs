using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock_Management.Model.Interface;

namespace Stock_Management.Model
{
    class ProductCatalogSingleTon : IProductCatalogSingleton
    {



        private static ProductCatalogSingleTon instance;

        private ProductCatalogSingleTon()
        {
        }

        public static ProductCatalogSingleTon Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProductCatalogSingleTon();
                }

                return instance;
            }
        }

        public void CreateProduct(Product p)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Product p)
        {
            throw new NotImplementedException();
        }

        public List<Product> FindProducts(string s)
        {
            throw new NotImplementedException();
        }

        public Product FindSpecificProduct(int i)
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

        public void UpdateProduct(Product p)
        {
            throw new NotImplementedException();
        }
    }
}
