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
		void OrderProduct(Product p, int amount);

		void LoadProductsAsync();
		void LoadSuppliersAsync();
	}
}
