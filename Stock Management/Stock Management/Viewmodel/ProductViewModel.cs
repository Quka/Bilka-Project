﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Stock_Management.Common;
using Stock_Management.Handler;
using Stock_Management.Model;
using Windows.UI.Xaml.Controls;

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
		public int OrderAmount { get; set; }

		public Supplier Supplier { get; set; }
        public ProductReturn ProductReturn { get; set; }

        public static Product SelectedProduct { get; set; }

		// Used when a supplier is picked from the dropdown in createProduct
		// this sets the selectedSupplier, which we use to pass to a method
		// which creates the supplier
		public static Supplier SelectedSupplier { get; set; }


        public ProductCatalogSingleton ProductCatalogSingleton { get; set; }
		public Handler.ProductHandler ProductHandler { get; set; }

		private ICommand _selectProductCommand;
		private ICommand _createProductCommand;
		private ICommand _updateProductCommand;
		private ICommand _deleteProductCommand;
		private ICommand _manualOrderCommand;
        private ICommand _returnProductCommand;

        public ICommand SelectProductCommand
		{
			get { return _selectProductCommand ?? (_selectProductCommand = new RelayArgCommand<Product>(p => ProductHandler.SetSelectedProduct(p))); }
			set { _selectProductCommand = value; }
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
		public ICommand ReturnProductCommand
        {
            get { return _returnProductCommand ?? (_returnProductCommand = new RelayCommand(ProductHandler.ReturnProduct)); }
            set { _returnProductCommand = value; }
        }
		public ICommand ManualOrderCommand
		{
			get { return _manualOrderCommand ?? (_manualOrderCommand = new RelayCommand(ProductHandler.ManualOrder)); }
			set { _manualOrderCommand = value; }
		}
		public ICommand ApproveOrderCommand { get; set; }

		public ProductViewModel()
        {
            ProductCatalogSingleton = ProductCatalogSingleton.Instance;
	        ProductHandler = new ProductHandler(this);
            DateTime dt = DateTime.Now;

            Product = new Product();
            Date = new DateTimeOffset(dt);
			Supplier = new Supplier();
		}

        
    }
}
