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
        public sealed class ProductCatalogSingleton
        {
            private static ProductCatalogSingleton instance = null;
            private static readonly object padlock = new object();

            ProductCatalogSingleton()
            {
            }

            public static ProductCatalogSingleton Instance
            {
                get
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new ProductCatalogSingleton();
                        }
                        return Instance;
                    }
                }
            }
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
