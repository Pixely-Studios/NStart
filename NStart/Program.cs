using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace NStart
{
	public static class Program
	{
		/// <summary>
		/// Entry point for the application's Kestrel Server
		/// </summary>
		/// <param name="args">Arguments used to start the Server</param>
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		/// <summary>
		/// Creates a request to build the host and configure the services
		/// </summary>
		/// <param name="args">Arguments used to start the server</param>
		/// <returns>A completely configured pipeline with the specific Kestrel server options</returns>
		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
	}
}
