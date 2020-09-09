using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;

namespace NStart.Extensions
{
	public static class LocalizationSetup
	{
		// Default UI Cultures
		internal const string DefaultCulture = "en-US";
		// List of supported cultures for Localization & Globalization
		internal static readonly CultureInfo[] SupportedCultures =
		{
			// Deutsch
			new CultureInfo("de"),
			// English
			new CultureInfo("en"),
			// English - US
			new CultureInfo("en-US"),
			// Español
			new CultureInfo("es"),
			// Français
			new CultureInfo("fr"),
			// Italiano
			new CultureInfo("it"),
			// 日本 - Japanese
			new CultureInfo("jp"),
			// 한국어 - Korean
			new CultureInfo("kr"),
			// Português
			new CultureInfo("pt"),
			// русский - Russian
			new CultureInfo("ru")
		};

		/// <summary>
		/// Platform wrapper for adding our custom localization configuration
		/// </summary>
		/// <param name="services">Collection of services to add this configuration</param>
		public static void AddCustomLocalization(this IServiceCollection services)
		{
			// Configure our Request Localization options
			services.Configure<RequestLocalizationOptions>(options =>
			{
				options.DefaultRequestCulture = new RequestCulture(culture: DefaultCulture, uiCulture: DefaultCulture);
				options.SupportedCultures = SupportedCultures;
				options.SupportedUICultures = SupportedCultures;
				options.RequestCultureProviders.Insert(0, new AcceptLanguageHeaderRequestCultureProvider());
			});
			// Add localization to our Application, and the RESX files are under the Resources directory
			services.AddLocalization(options => options.ResourcesPath = "Resources");
		}
	}
}
