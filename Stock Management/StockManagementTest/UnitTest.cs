
using System;
using System.Collections.ObjectModel;
using System.Reflection.Metadata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stock_Management;
using Stock_Management.Model;

namespace StockManagementTest
{
    [TestClass]
    public class UnitTest1
    {
		
        [TestMethod]
        public void TestDeleteProduct()
        {

            Product p = new Product();

            ProductCatalogSingleton.Instance.ProductList.Add(p);

            ProductCatalogSingleton.Instance.DeleteProduct(p);

            CollectionAssert.Contains(ProductCatalogSingleton.Instance.ProductList,p);

            
         }
		
    }
}
