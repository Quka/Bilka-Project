using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using StockManagementWS;

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
				Product p = new Product();

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
