using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StockManagementWS;
using Product = Stock_Management.Model.Product;

namespace TestWebservice
{
	class Program
	{
		static void Main(string[] args)
		{
			const string serverUrl = "http://localhost:55001";
			HttpClientHandler handler = new HttpClientHandler();
			handler.UseDefaultCredentials = true;
			/*
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
						products = products.ToList();

						Console.WriteLine(products);
					}

					Console.WriteLine(response.RequestMessage);
					Console.ReadKey();
				}
				catch (Exception)
				{
					throw;
				}
			}*/

			

			using (var client = new HttpClient(handler))
			{
				Product p = new Product(123, "test", 123.12m, 5, "test description", new Supplier(), 3, 2, DateTime.Now);
				string postBody = JsonConvert.SerializeObject(p);
				

				client.BaseAddress = new Uri(serverUrl);
				client.DefaultRequestHeaders.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				
				try
				{
					Console.WriteLine(postBody);
					Console.WriteLine(client.PostAsJsonAsync("api/Products", postBody).Result);
					Console.ReadKey();
				}
				catch (Exception ex)
				{
					//new MessageDialog(ex.Message).ShowAsync();
					Console.WriteLine(ex);
				}
			}
			
		}
	}
}
