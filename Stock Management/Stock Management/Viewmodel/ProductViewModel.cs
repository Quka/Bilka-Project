using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Stock_Management.Common;
using Stock_Management.Handler;
using Stock_Management.Model;

namespace Stock_Management.Viewmodel
{
    class ProductViewModel
	{
		// We might only need Product property, instead of itemnr etc...
        // Pretty sure we need the other properties when we bind them later on, at least they were indeeded in the eventmaker example.
		public Product Product { get; set; }
		public int ItemNr { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
		public List<Supplier> ListSupplier { get; set; }

		public static Product SelectedProduct { get; set; }
        public ProductCatalogSingleton ProductCatalogSingleton { get; set; }
		public Handler.ProductHandler ProductHandler { get; set; }

		private ICommand _createProductCommand;
	    private ICommand _selectedProductCommand;

		public ICommand FindProductsCommand { get; set; }
		

		public ICommand CreateProductCommand
	    {
		    get { return _createProductCommand ?? (_createProductCommand = new RelayCommand(ProductHandler.CreateProduct)); }
		    set { _createProductCommand = value; }
		}

		public ICommand UpdateProductCommand { get; set; }
		public ICommand DeleteProductCommand { get; set; }
		public ICommand ManualOrderCommand { get; set; }
		public ICommand ReturnProductCommand { get; set; }
		public ICommand ApproveOrderCommand { get; set; }
		public ICommand KeyUpSearchSupplier { get; set; }
       

        public ICommand SelectProductCommand
        {
            get { return _selectedProductCommand ?? (_selectedProductCommand = new RelayArgCommand<Product>(p => ProductHandler.SetSelectedProduct(p))); }
            set { _selectedProductCommand = value; }
        }


        public ProductViewModel()
        {
            ProductCatalogSingleton = ProductCatalogSingleton.Instance;
	        ProductHandler = new ProductHandler(this);
		}

        
    }
}
