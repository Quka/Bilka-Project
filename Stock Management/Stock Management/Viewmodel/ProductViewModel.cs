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
        // Instantiate Product obj and set it through the view
		// example: we can later post the entire Product object to the webservice
		// this way we don't need individual properties of Product, in the ViewModel

        public Product Product { get; set; }
	    public string StringPrice { get; set; }
        //public DateTimeOffset DateTimeWorks { get; set; }

        public DateTimeOffset Date { get; set; }


		public static Product SelectedProduct { get; set; }
	    public static Supplier SelectedSupplier { get; set; }

        public ProductCatalogSingleton ProductCatalogSingleton { get; set; }
		public Handler.ProductHandler ProductHandler { get; set; }

		private ICommand _selectedProductCommand;
	    private ICommand _selectedSupplierCommand;
		private ICommand _createProductCommand;
		private ICommand _updateProductCommand;
		private ICommand _deleteProductCommand;
		private ICommand _manualOrderCommand;

		public ICommand FindProductsCommand { get; set; }
		public ICommand SelectProductCommand
		{
			get { return _selectedProductCommand ?? (_selectedProductCommand = new RelayArgCommand<Product>(p => ProductHandler.SetSelectedProduct(p))); }
			set { _selectedProductCommand = value; }
		}

	    public ICommand SelectSupplierCommand
	    {
	        get { return _selectedSupplierCommand ?? (_selectedSupplierCommand = new RelayArgCommand<Supplier>(s => ProductHandler.SetSelectedSupplier(s))); }
	        set { _selectedSupplierCommand = value; }
	    }

	    public ICommand CreateProductCommand
        {
            get { return _createProductCommand ?? (_createProductCommand = new RelayCommand(ProductHandler.CreateProduct)); }
            set { _createProductCommand = value; }
        }
        public ICommand UpdateProductCommand
		{
			get { return _updateProductCommand ?? (_updateProductCommand = new RelayCommand(ProductHandler.UpdateProduct)); }
			set { _createProductCommand = value; }
		}
		public ICommand DeleteProductCommand
		{
			get { return _deleteProductCommand ?? (_deleteProductCommand = new RelayCommand(ProductHandler.DeleteProduct)); }
			set { _deleteProductCommand = value; }
		}

		public ICommand ManualOrderCommand
		{
			get { return _manualOrderCommand ?? (_manualOrderCommand = new RelayCommand(ProductHandler.ManualOrder)); }
			set { _manualOrderCommand = value; }
		}
		public ICommand ReturnProductCommand { get; set; }
		public ICommand ApproveOrderCommand { get; set; }
		public ICommand KeyUpSearchSupplier { get; set; }
       

        


        public ProductViewModel()
        {
            ProductCatalogSingleton = ProductCatalogSingleton.Instance;
	        ProductHandler = new ProductHandler(this);
            //DateTime dt = DateTime.Now;

            Product = new Product();
            //Date = new DateTimeOffset(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, 0, 0, new TimeSpan());

            //CreateProductCommand = new RelayCommand(ProductHandler.CreateProduct);

            
		}

        
    }
}
