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
	[System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "RCS1102:Make class static.", Justification = "This cannot be null. The program.cs file will fail to start up the system.")]
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public static void ConfigureServices(IServiceCollection services)
		{
			services.AddRouting();

			services.AddApplicationInsightsTelemetry();

			services.AddCustomLocalization();

			services.AddRazorPages()
				.AddViewLocalization(LanguageViewLocationExpanderFormat.SubFolder)
				.AddDataAnnotationsLocalization();

			// Singleton Services
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (app is null)
				throw new ArgumentNullException(nameof(app));
			if (env is null)
				throw new ArgumentNullException(nameof(env));

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler(configure => configure.UseStatusCodePagesWithReExecute("/error/{0}"));
				app.UseHsts();
			}

			var localizationOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value;
			app.UseRequestLocalization(localizationOptions);

			app.UseStaticFiles();

			app.UseHttpsRedirection();

			app.UseCookiePolicy();

			app.UseRouting();

			app.UseEndpoints(endpoints => endpoints.MapRazorPages());
		}
	}
}
