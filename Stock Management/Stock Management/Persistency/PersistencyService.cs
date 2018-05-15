using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Newtonsoft.Json;
using Stock_Management.Model;

namespace Stock_Management.Persistency
{
    public class PersistencyService
    {
	    private static string serverUrl = "http://localhost:55001";
	    private static HttpClientHandler handler = new HttpClientHandler();

	    public PersistencyService()
	    {
		    handler.UseDefaultCredentials = true;
		}

	    public static async void InsertProductAsync(Product p)
	    {
		    
		    using (var client = new HttpClient(handler))
	        {
		        string postBody = JsonConvert.SerializeObject(p);

		        // Convert the string body to bytes, because json returns 400 status errors
		        byte[] msgBytes = Encoding.UTF8.GetBytes(postBody);
		        var content = new ByteArrayContent(msgBytes);
		        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

		        client.BaseAddress = new Uri(serverUrl);
		        client.DefaultRequestHeaders.Clear();
		        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

		        try
		        {
					// insert
			        HttpResponseMessage response = client.PostAsync("api/Products", content).Result;
			        string responseBody = await response.Content.ReadAsStringAsync();
			        new MessageDialog(responseBody);

		        }
		        catch (Exception ex)
		        {
			        //new MessageDialog(ex.Message).ShowAsync();
		        }
	        }
		}
		public static async void UpdateProductAsync(Product p)
	    {
		    throw new NotImplementedException();
	    }
		public static async void DeleteProductAsync(Product p)
        {
            throw new NotImplementedException();
        }

        public static async Task<Employee> GetUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public static async void InsertOrder(Order o)
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
			using (var client = new HttpClient(handler))
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

        public static async void UpdateOrder(Order o)
        {
            throw new NotImplementedException();
        }

	    private class MessageDialogHelper
	    {
		    public static async void Show(string content, string title)
		    {
			    MessageDialog messageDialog = new MessageDialog(content, title);
			    await messageDialog.ShowAsync();
		    }
	    }
	}
}
