using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Store;
using Windows.UI.Popups;
using Microsoft.Xaml.Interactions.Core;
using Stock_Management.Model.Interface;
using Stock_Management.Persistency;

namespace Stock_Management.Model
{
    public class ProductCatalogSingleton : IProductCatalogSingleton
    {
		//Lazy Loading is initializing the member the first time it is requested
		private static ProductCatalogSingleton _instance;
        public static ProductCatalogSingleton Instance
        {
            get { return _instance ?? (_instance = new ProductCatalogSingleton()); }
        }

        public ObservableCollection<Product> ProductList { get; set; }
        public ObservableCollection<Supplier> SupplierList { get; set; }
	    public ObservableCollection<Order> OrderList { get; set; }
	    public ObservableCollection<ProductReturn> ProductReturnList { get; set; }
        
        private ProductCatalogSingleton()
        {
            SupplierList  = new ObservableCollection<Supplier>();
	        LoadSuppliersAsync();

	        OrderList = new ObservableCollection<Order>();
	        LoadOrdersAsync();

	        ProductReturnList = new ObservableCollection<ProductReturn>();
	        LoadProductReturnsAsync();

	        ProductList = new ObservableCollection<Product>();
	        LoadProductsAsync();
		}

        public void CreateProduct(Product p)
        {
			// TODO check if varenr og navn eksisterer i forvejen
			// if check here


	        if (p.Supplier == null)
	        {
				// Supplier or any of suppliers properties are null
				throw new ArgumentNullException("Some supplier information is missing");
	        }

	        if (p.Supplier.Id != 0)
	        {
		        // If the supplier is not 0, that means the Supplier was selected from the dropdownlist

				// Set the SupplierId on the Product
		        p.SupplierId = p.Supplier.Id;
	        }
	        else
	        {
				// The supplier id is zero, which means it was typed in and not selected
				// should now check if a supplier already exists with that name or create a new one

		        // Check if the Supplier already exists in the list
		        if (SupplierList.Where(s => s.Id.Equals(p.SupplierId)).Count() > 0)
		        {
			        // Exists in the list update the Supplier instead
			        UpdateSupplier(p.Supplier);
			        new MessageDialog("Updating Supplier").ShowAsync();
				}
		        else
		        {
			        // Does not exist in the list, create a new one
			        CreateSupplier(p.Supplier);
			        new MessageDialog("Creating Supplier").ShowAsync();
				}
			}

			try
			{
				// Add in DB1   
		        PersistencyService.InsertProductAsync(p);

				// Add to ProductList
		        ProductList.Add(p);
			}
	        catch (Exception e)
	        {
		        Debug.WriteLine(e);
	        }
        }

		public void DeleteProduct(Product p)
        {
	        try
	        {
				// Remove from DB
		        PersistencyService.DeleteProductAsync(p);

				// Remove from List
		        ProductList.Remove(p);
	        }
	        catch (Exception e)
	        {
		        Debug.WriteLine(e);
	        }
		}
        public void UpdateProduct(Product p)
        {
			// TODO update product in the ProductCatalogSingleton list as well

	        // Update product in DB
	        PersistencyService.UpdateProductAsync(p);
        }

        public void OrderProduct(Product p, int amount)
        {
			// Create an order 
			
			// Sets datetime variable for date and estDelivery. As DateTime can't be null so we set
			// the property to the same thing. If they are the same, that means estDilevery has not been set
	        DateTime now = DateTime.Now;

	        // EnumStatus: I am using the built in EnumStatus' and do a toString on them as the DB takes a string
			Order o = new Order(p.Id, p.SupplierId, ToString(), amount, now, now );

			// Insert order
	        PersistencyService.InsertOrder(o);
        }

		/// <summary>
		/// Load all Products, and product properties (Supplier, OrderList, ProductReturnList)
		/// from the DB into the app ProductList
		/// </summary>
		public async void LoadProductsAsync()
	    {
		    List<Product> products = null;

		    try
		    {
			    products = await PersistencyService.LoadProductsAsync();
		    }
		    catch (Exception e)
		    {
			    Debug.WriteLine(e);
			    throw;
		    }

		    if (products != null)
		    {
			    foreach (Product p in products)
			    {
				    // Set the Supplier, Orders, and ProductReturns for the current Product
					// Product has a required supplier
				    try
				    {
						// Find the single supplier matching the supplier foreign key on the product
					    p.Supplier = SupplierList.Single(s => s.Id.Equals(p.SupplierId));
				    }
				    catch (Exception e)
				    {
					    Debug.WriteLine(e);
					    throw;
				    }

				    
					// Get Orders in the OrderList with a foreign key to the current Product in the foreach
					List<Order> productOrderList = OrderList.Where(o => o.ProductId.Equals(p.Id)).ToList();
				    if (productOrderList != null && productOrderList.Count > 0)
				    {
					    p.FillOrderList(productOrderList);
					}

					// Get ProductReturns in the prList with a foreign key to the current Product in the foreach 
					List<ProductReturn> prList = ProductReturnList.Where(pr => pr.ProductId.Equals(p.Id)).ToList();
				    if (prList != null && prList.Count > 0)
				    {
					    p.FillProductReturnList(prList);
					}

					// At last, add the product the productList
				    ProductList.Add(p);
			    }
			}
		    else
		    {
				throw new ArgumentNullException("Products list null");
		    }
		}

		public async void LoadSuppliersAsync()
		{
			List<Supplier> suppliers = null;

			try
	        {
		        suppliers = await PersistencyService.LoadSuppliersAsync();
			}
	        catch (Exception e)
	        {
		        Debug.WriteLine(e);
		        throw;
	        }

			if (suppliers != null)
			{
				foreach (Supplier supplier in suppliers)
				{
					SupplierList.Add(supplier);
				}
			}
			else
			{
				throw new ArgumentNullException("Suppliers list null");
			}
	        
		}

	    public async void LoadOrdersAsync()
	    {
		    List<Order> orders = null;
			try
			{
				orders = await PersistencyService.LoadOrdersAsync();
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
				throw;
			}

		    if (orders != null)
		    {
			    foreach (Order order in orders)
			    {
				    OrderList.Add(order);
			    }
			}
		    else
		    {
				throw new ArgumentNullException("Orders list null");
		    }
		}

	    public async void LoadProductReturnsAsync()
	    {
		    List<ProductReturn> productReturns = null;

			try
		    {
			    productReturns = await PersistencyService.LoadProductReturnsAsync();
		    }
		    catch (Exception e)
		    {
			    Debug.WriteLine(e);
			    throw;
		    }

		    if (productReturns != null)
		    {
			    foreach (ProductReturn pr in productReturns)
			    {
				    productReturns.Add(pr);
			    }
			}
		    else
		    {
				throw new ArgumentNullException("ProductReturns list null");
		    }
		}

		public void CreateSupplier(Supplier s)
		{
			try
			{
				PersistencyService.InsertSupplier(s);
			}
			catch (Exception e)
			{
				Debug.WriteLine(e);
				throw;
			}
		}

	    public void UpdateSupplier(Supplier s)
	    {
		    PersistencyService.UpdateSupplier(s);
	    }



        public void CreateProductReturn(ProductReturn r)
        {
            //add preconditions later
            //if (r.Amount == null)
            //{
             
            //    throw new ArgumentNullException("Amount is not selected");
            //}

           
  
            new MessageDialog("Creating ProductReturn").ShowAsync();
            try
            {
                
                PersistencyService.InsertProductReturnAsync(r);

                // Add to ProductReturns
              
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}