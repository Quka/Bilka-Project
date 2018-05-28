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
        
        public List<Product> FindProducts(string s)
        {
            throw new NotImplementedException();
        }

        public void SetSelectedProduct(Product p)
        {
            ProductViewModel.SelectedProduct = p;
        }

        public void CreateProduct()
        {
			ProductViewModel.Product.Price = Convert.ToDecimal(ProductViewModel.StringPrice);
            ProductViewModel.Product.RestockPeriod = ProductViewModel.Date.Date;

			ProductViewModel.Product.Supplier = ProductViewModel.Supplier;

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


            // TEST
            // TODO make this update dynamic, is hardcoded now
            //      Product testProduct = new Product(
            //       1,
            //       9909,
            //       "UPDATED Test Product",
            //       500.50m,
            //       5,
            //       "UPDATED Test status",
            //	"UPDATED test description",
            //       3,
            //       2,
            //       DateTime.Now
            //      );

            //// Update Product with ID 4
            //      testProduct.Id = 4;

            //ProductViewModel.ProductCatalogSingleton.UpdateProduct(testProduct);
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
            throw new NotImplementedException();
        }

        public void ApproveOrder()
        {
            throw new NotImplementedException();
        }

	    private void CommandInvokedHandler(IUICommand command)
	    {
		    ProductViewModel.ProductCatalogSingleton.DeleteProduct(ProductViewModel.SelectedProduct);
	    }
	}
}
