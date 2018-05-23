using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Stock_Management.Model;

namespace Stock_Management.Handler
{
    interface IProductHandler
    {
        List<Product> FindProducts(String s);
        void SetSelectedProduct(Product p);

        void CreateProduct();
        void UpdateProduct();
        void DeleteProduct();

	    void ManualOrder();
        void ReturnProduct();
        void ApproveOrder();


    }
}