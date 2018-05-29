using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Stock_Management.Model;
using Stock_Management.Viewmodel;

namespace Stock_Management.Handler
{
    class ProductHandler : IProductHandler
    {
        public ProductViewModel ProductViewModel { get; set; }

	    public ProductHandler(ProductViewModel productViewModel)
	    {
		    ProductViewModel = productViewModel;
	    }

        public void CreateProduct()
        {
			ProductViewModel.Product.Price = Convert.ToDecimal(ProductViewModel.StringPrice);
            ProductViewModel.Product.RestockPeriod = ProductViewModel.Date.Date;

			if (ProductViewModel.SelectedSupplier != null)
	        {
		        // IF a selected supplier exists, that means the supplier was selected from the dropdown
		        // pass the selectedSupplier to the Product obj
				ProductViewModel.Product.Supplier = ProductViewModel.SelectedSupplier;
			}
			else
			{
				// ELSE the selected supplier was typed in, meaning it might be a new supplier to be created
				// or the supplier should be searched if it already exists, and then should be updated
				// this supplier is missing an ID
				ProductViewModel.Product.Supplier = ProductViewModel.Supplier;
			}

			try
	        {
		        ProductViewModel.ProductCatalogSingleton.CreateProduct(ProductViewModel.Product);
			}
			catch (ArgumentNullException e)
			{
				new MessageDialog(e.Message).ShowAsync();
			}
        }
        public void UpdateProduct()
        {

            try
            {
                ProductCatalogSingleton.Instance.UpdateProduct(ProductViewModel.SelectedProduct);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                
            }
        }
        public void DeleteProduct()
        {   
	        try
	        {
	            ProductCatalogSingleton.Instance.DeleteProduct(ProductViewModel.SelectedProduct);
            }
	        catch (Exception e)
	        {
		        Debug.WriteLine(e);
	        }
        }

        public void ManualOrder()
        {
			// TEST
	        // TODO Make Product to order dynamic. Currently creates an order for the latest product in the list
		    //ObservableCollection<Product> productList = ProductViewModel.ProductCatalogSingleton.ProductList;
            Product p = ProductViewModel.SelectedProduct;
	        int amount = ProductViewModel.OrderAmount;

			ProductViewModel.ProductCatalogSingleton.OrderProduct(p, amount);
        }
        public void ReturnProduct()
        {
            try
            {
                ProductViewModel.ProductCatalogSingleton.CreateProductReturn(ProductViewModel.ProductReturn);
            }
            catch (ArgumentNullException e)
            {
                new MessageDialog(e.Message).ShowAsync();
            }
        }
	    public void ApproveOrder()
	    {
		    throw new NotImplementedException();
	    }

		public void SetSelectedProduct(Product p)
	    {
		    ProductViewModel.SelectedProduct = p;
	    }
	}
}
