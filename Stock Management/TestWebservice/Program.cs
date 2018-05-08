using System;
using System.Collections.Generic;
using System.IO;
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

			// SELECT example
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
			}

			// INSERT example
			/*
			using (var client = new HttpClient(handler))
			{
				Product p = new Product(1, 1234, "test", 123.12m, 5, "Test status", "test description", 3, 2, DateTime.Now);
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
					Console.WriteLine("INSERT Product");
					Console.WriteLine(postBody);
					Console.WriteLine(content.ToString());

					Console.WriteLine(client.PostAsync("api/Products", content).Result);
					Console.ReadKey();
				}
				catch (Exception ex)
				{
					//new MessageDialog(ex.Message).ShowAsync();
					Console.WriteLine(ex);
				}
			}
			*/

			// UPDATE example
			/*
			using (var client = new HttpClient(handler))
			{
				Product p = new Product(1, 12345, "UPDATE TEST", 123.12m, 5, "Test status", "test description", 3, 2, DateTime.Now);
				
				// Set the product ID to change
				p.Id = 2;
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
					Console.WriteLine("PUT Product\n");
					Console.WriteLine(postBody);
					Console.WriteLine(content.ToString());

					Console.WriteLine(client.PutAsync("api/Products/2", content).Result);
					Console.ReadKey();
				}
				catch (Exception ex)
				{
					//new MessageDialog(ex.Message).ShowAsync();
					Console.WriteLine(ex);
				}
			}
			*/

			// DELETE example
			/*
			using (var client = new HttpClient(handler))
			{
				client.BaseAddress = new Uri(serverUrl);
				client.DefaultRequestHeaders.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				try
				{
					Console.WriteLine("DELETE Product\n");

					Console.WriteLine(client.DeleteAsync("api/Products/2").Result);
					Console.ReadKey();
				}
				catch (Exception ex)
				{
					//new MessageDialog(ex.Message).ShowAsync();
					Console.WriteLine(ex);
				}
			}
			*/
		}
	}
}
