using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
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

			using (var client = new HttpClient(handler))
			{
				Product p = new Product(123, "test", 123.12m, 5, "test description", new Supplier(), 3, 2, DateTime.Now);
				client.BaseAddress = new Uri(serverUrl);
				client.DefaultRequestHeaders.Clear();
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

				try
				{
					client.PostAsJsonAsync("api/Products", p);
				}
				catch (Exception ex)
				{
					//new MessageDialog(ex.Message).ShowAsync();
				}
			}
		}
	}
}
