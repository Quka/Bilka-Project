using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Stock_Management.Model;

namespace Stock_Management.Viewmodel
{
    class ProductViewModel
    {
        public int ItemNr { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public Product SelectedProduct { get; set; }
        public Product Product { get; set; }
        public ProductCatalogSingleton ProductCatalogSingleton { get; set; }
        public List<Supplier> ListSupplier { get; set; }
        public ICommand FindProductsCommand { get; set; }
        public ICommand SelectProductCommand { get; set; }
        public ICommand CreateProductCommand { get; set; }
        public ICommand UpdateProductCommand { get; set; }
        public ICommand DeleteProductCommand { get; set; }
        public ICommand ManualOrderCommand { get; set; }
        public ICommand ReturnProductCommand { get; set; }
        public ICommand ApproveOrderCommand { get; set; }
        public ICommand KeyUpSearchSupplier { get; set; }
       

        public ProductViewModel()
        {
            ProductCatalogSingleton = ProductCatalogSingleton.Instance;


        }

        
    }
}
