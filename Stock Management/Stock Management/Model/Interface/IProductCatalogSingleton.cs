using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stock_Management.Model.Interface
{
	interface IProductCatalogSingleton
	{
		void CreateProduct(Product p);
		void DeleteProduct(Product p);
		void UpdateProduct(Product p);

		Product FindSpecificProduct(int i);
		List<Product> FindProducts(String s);

		ObservableCollection<Product> LoadProductsAsync();

		void OrderProduct(Product p, int amount);
	}
}
