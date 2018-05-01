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

        private ProductCatalogSingleTon() { }

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
            instance.CreateProduct(p);
        }

        public void DeleteProduct(Product p)
        {
            instance.DeleteProduct(p);
        }

        public List<Product> FindProducts(string s)
        {
            return instance.FindProducts(s);
        }

        public Product FindSpecificProduct(int i)
        {
            return instance.FindSpecificProduct(i);
        }

        public ObservableCollection<Product> LoadProductsAsync()
        {
            return instance.LoadProductsAsync();
        }

        public void OrderProduct(Product p, int amount)
        {
            instance.OrderProduct(p, amount);
        }

        public void UpdateProduct(Product p)
        {
            instance.UpdateProduct(p);
        }
    }
}
