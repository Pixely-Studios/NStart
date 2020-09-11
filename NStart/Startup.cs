using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NStart.Extensions;

namespace NStart
{
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1052:Static holder types should be Static or NotInheritable", Justification = "This cannot be null. The program.cs file will fail to start up the system.")]
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "RCS1102:Make class static.", Justification = "This cannot be null. The program.cs file will fail to start up the system")]
	public class Startup
	{
		/// <summary>
		/// Adds services to this application's container
		/// </summary>
		/// <param name="services">Collection of base services defined by the host</param>
		/// <exception cref="ArgumentNullException">A invalid service collection was supplied to the application's container</exception>
		public static void ConfigureServices(IServiceCollection services)
		{
			// If our service collection if null, throw a new ArgumentNullException
			if (services is null)
				throw new ArgumentNullException(nameof(services));

			// Add Routing
			services.AddRouting();
			// Add Application Insights for advanced telemetry
			services.AddApplicationInsightsTelemetry();
			// Add our custom localization settings
			services.AddCustomLocalization();
			// Add Razor Pages + the supported Localization
			services.AddRazorPages()
				.AddViewLocalization(LanguageViewLocationExpanderFormat.SubFolder)
				.AddDataAnnotationsLocalization();
			// Singleton Services
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
		}

		/// <summary>
		/// Configures the HTTP Pipeline
		/// </summary>
		/// <param name="app">Configuration of the Application's Request Pipeline</param>
		/// <param name="env">Information of the current Hosting Environment</param>
		/// <exception cref="ArgumentNullException">A invalid ApplicationBuilder or WebHostEnvironment were supplied to configure the Request Pipeline.</exception>
		public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			// If our AppBuilder or WebHostEnvironment are null, throw a ArgumentNullException
			if (app is null)
				throw new ArgumentNullException(nameof(app));
			if (env is null)
				throw new ArgumentNullException(nameof(env));
			// If we are on a Development Environment
			if (env.IsDevelopment())
			{
				// Use a fully detailed Developer Exception Page
				app.UseDeveloperExceptionPage();
			}
			// If we are not on a Development Environment
			else
			{
				// Use a custom Exception handler that responds on the specified route
				app.UseExceptionHandler(configure => configure.UseStatusCodePagesWithReExecute("/error/{0}"));
				// Use HSTS for Strict Transport Security Headers
				app.UseHsts();
			}
			// Get our RequestLocalization Options and add them to our application's pipeline
			var localizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value;
			app.UseRequestLocalization(localizationOptions);
			// Add the support for Static Files (This allows us to use the wwwroot folder)
			app.UseStaticFiles();
			// Add the support for HTTP -> HTTPS redirection
			app.UseHttpsRedirection();
			// Adds Routing to this application's pipeline
			app.UseRouting();
			// Adds the support for Endpoints (Like SignalR hubs) and maps all the Razor Pages in the application
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapRazorPages();

				endpoints.MapControllers();
			});
		}
	}
}
