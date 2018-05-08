using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Stock_Management.Model;
using Stock_Management.PersistencyService.Interface;

namespace Stock_Management.PersistencyService
{
    class PersistencyService
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

        public static async Task<List<Order>> LoadOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public static async Task<List<ProductReturn>> LoadProductReturnsAsync()
        {
            throw new NotImplementedException();
        }

        public static async Task<List<Product>> LoadProductsAsync()
        {
	        string serverUrl = "http://localhost:55001";
	        HttpClientHandler HttpClientHandler = new HttpClientHandler();
	        HttpClientHandler.UseDefaultCredentials = true;

			using (var client = new HttpClient(HttpClientHandler))
			{
				client.BaseAddress = new Uri(serverUrl);
				client.DefaultRequestHeaders.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				try
				{
					var response = client.GetAsync("api/Products").Result;
					if (response.IsSuccessStatusCode)
					{
						var products = response.Content.ReadAsAsync<IEnumerable<Product>>().Result;

						return products.ToList();
					}

					return null;
				}
				catch (Exception)
				{
					throw;
				}
			}
		}

        public void UpdateOrder(Order o)
        {
            throw new NotImplementedException();
        }
    }
}
