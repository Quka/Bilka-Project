using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Newtonsoft.Json;
using Stock_Management.Model;

namespace Stock_Management.Persistency
{
    public class PersistencyService
    {
	    public static async void InsertProductAsync(Product p)
	    {
			const string serverUrl = "http://localhost:55001";
			HttpClientHandler handler = new HttpClientHandler();
			handler.UseDefaultCredentials = true;

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
					HttpResponseMessage httpResponseMessage = client.PostAsync("api/Products", content).Result;
					await new MessageDialog(httpResponseMessage.Content.ReadAsStringAsync().Result).ShowAsync();
		        }
		        catch (Exception e)
		        {
			        await new MessageDialog(e.Message).ShowAsync();
		        }
	        }
		}
		public static async void UpdateProductAsync(Product p)
	    {
		    const string serverUrl = "http://localhost:55001";
		    HttpClientHandler handler = new HttpClientHandler();
		    handler.UseDefaultCredentials = true;

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
					HttpResponseMessage httpResponseMessage = client.PutAsync("api/Products/" + p.Id, content).Result;
					await new MessageDialog("Updated: " + httpResponseMessage.IsSuccessStatusCode.ToString()).ShowAsync();
				}
				catch (Exception e)
				{
					await new MessageDialog(e.Message).ShowAsync();
				}
			}
		}

        public static async Task<List<Supplier>> LoadSuppliersAsync()
        {
            throw new NotImplementedException();
        }

        public static async void DeleteProductAsync(Product p)
        {
			const string serverUrl = "http://localhost:55001";
	        HttpClientHandler handler = new HttpClientHandler();
	        handler.UseDefaultCredentials = true;

	        using (var client = new HttpClient(handler))
	        {
		        client.BaseAddress = new Uri(serverUrl);
		        client.DefaultRequestHeaders.Clear();
		        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

		        try
		        {
			        HttpResponseMessage httpResponseMessage = client.DeleteAsync("api/Products/" + p.Id).Result;
					await new MessageDialog("Deleted: " + httpResponseMessage.Content.ReadAsStringAsync().Result).ShowAsync();
				}
		        catch (Exception e)
		        {
			        await new MessageDialog(e.Message).ShowAsync();
		        }
	        }
		}

        public static async Task<Employee> GetUser(string username, string password)
        {
            throw new NotImplementedException();
        }

        public static async void InsertOrder(Order o)
        {
            const string serverUrl = "http://localhost:55001";
			HttpClientHandler handler = new HttpClientHandler();
			handler.UseDefaultCredentials = true;

		    using (var client = new HttpClient(handler))
	        {
		        string postBody = JsonConvert.SerializeObject(o);

		        // Convert the string body to bytes, because json returns 400 status errors
		        byte[] msgBytes = Encoding.UTF8.GetBytes(postBody);
		        var content = new ByteArrayContent(msgBytes);
		        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

		        client.BaseAddress = new Uri(serverUrl);
		        client.DefaultRequestHeaders.Clear();
		        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

		        try
		        {
					HttpResponseMessage httpResponseMessage = client.PostAsync("api/Orders", content).Result;
					await new MessageDialog(httpResponseMessage.Content.ReadAsStringAsync().Result).ShowAsync();
		        }
		        catch (Exception e)
		        {
			        await new MessageDialog(e.Message).ShowAsync();
		        }
	        }
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
	        const string serverUrl = "http://localhost:55001";
	        HttpClientHandler handler = new HttpClientHandler();
	        handler.UseDefaultCredentials = true;

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
				catch (Exception e)
				{
					await new MessageDialog(e.Message).ShowAsync();
					return null;
				}
			}
		}

        public static async void UpdateOrder(Order o)
        {
            throw new NotImplementedException();
        }
	}
}
