using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock_Management.Model;

namespace Stock_Management.PersistencyService.Interface
{
	interface IPersistencyService
	{
		/*
		 * Cannot implement an interface with static methods
		 *
		 * >> You can't define static members on an interface in C#.
		 * >> An interface is a contract for instances.
		 */

		void InsertProductAsync(Product p);
		void DeleteProductAsync(Product p);
		void UpdateProductAsync(Product p);
		Task<List<Product>> LoadProductsAsync();

		void InsertOrder(Order o);
		void UpdateOrder(Order o);
		Task<List<Order>> LoadOrdersAsync();

		Task<List<ProductReturn>> LoadProductReturnsAsync();

		Employee GetUser(String username, String password);
	}
}
