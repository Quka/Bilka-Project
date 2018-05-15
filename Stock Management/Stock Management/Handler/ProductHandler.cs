using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Stock_Management.Model;
using Stock_Management.Viewmodel;

namespace Stock_Management.Handler
{
    class ProductHandler : IProductHandler
    {
        public ProductViewModel ProductViewModel { get; set; }
        
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
            throw new NotImplementedException();
        }

        public void UpdateProduct()
        {
            throw new NotImplementedException();
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
    }
}
