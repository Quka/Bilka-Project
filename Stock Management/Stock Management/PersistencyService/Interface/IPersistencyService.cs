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
		void InsertProductAsync(Product p);
		void DeleteProductAsync(Product p);
		void UpdateProductAsync(Product p);
		ObservableCollection<Product> LoadProductsAsync();

		void InsertOrder(Order o);
		void UpdateOrder(Order o);
		ObservableCollection<Order> LoadOrdersAsync();

		ObservableCollection<ProductReturn> LoadProductReturnsAsync();

		Employee GetUser(String username, String password);
	}
}
