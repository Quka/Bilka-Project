using System;
using System.Collections.Generic;
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
            // TODO add dynamic product and remove test produt

            Product createNewProduct =
                new Product(ProductViewModel.SupplierId, ProductViewModel.ItemNr, ProductViewModel.Name,
                            ProductViewModel.Price, ProductViewModel.Stock, ProductViewModel.Status,
                            ProductViewModel.Description, ProductViewModel.MinStock, ProductViewModel.RestockAmount,
                            DateTime.Now);
            ProductViewModel.ProductCatalogSingleton.CreateProduct(createNewProduct);




            //      Product testProduct = new Product( 1,9909,"Name of the product",500.50m,5,"The status of the product","Description",3,2,DateTime.Now
            //       //1,
            //       //9909,
            //       //"Test Product",
            //       //500.50m,
            //       //5,
            //       //"Test status",
            //       //"test description",
            //       //3,
            //       //2,
            //       //DateTime.Now
            //      );

            //ProductViewModel.ProductCatalogSingleton.CreateProduct(testProduct);
        }

        public void UpdateProduct()
        {
			// TODO make this update dynamic, is hardcoded now
	        Product testProduct = new Product(
		        1,
		        9909,
		        "UPDATED Test Product",
		        500.50m,
		        5,
		        "UPDATED Test status",
				"UPDATED test description",
		        3,
		        2,
		        DateTime.Now
	        );

			// Update Product with ID 2
	        testProduct.Id = 4;

	        ProductViewModel.ProductCatalogSingleton.UpdateProduct(testProduct);
        }

        public void DeleteProduct()
        {
            throw new NotImplementedException();
        }

        public void ManualOrder()
        {
            throw new NotImplementedException();
        }

        public void ReturnProduct()
        {
            throw new NotImplementedException();
        }

        public void ApproveOrder()
        {
            throw new NotImplementedException();
        }

        public ICommand KeyUpSearchSupplier()
        {
            throw new NotImplementedException();
        }

	    private void CommandInvokedHandler(IUICommand command)
	    {
		    ProductViewModel.ProductCatalogSingleton.DeleteProduct(ProductViewModel.SelectedProduct);
	    }
	}
}
