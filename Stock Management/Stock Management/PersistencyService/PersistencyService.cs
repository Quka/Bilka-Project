using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stock_Management.Model;
using Stock_Management.PersistencyService.Interface;

namespace Stock_Management.PersistencyService
{
    class PersistencyService : IPersistencyService
    {
	    public void InsertProductAsync(Product p)
	    {
		    throw new NotImplementedException();
	    }
		public void UpdateProductAsync(Product p)
	    {
		    throw new NotImplementedException();
	    }
		public void DeleteProductAsync(Product p)
        {
            throw new NotImplementedException();
        }

        public Employee GetUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void InsertOrder(Order o)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Order> LoadOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<ProductReturn> LoadProductReturnsAsync()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Product> LoadProductsAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateOrder(Order o)
        {
            throw new NotImplementedException();
        }
    }
}
