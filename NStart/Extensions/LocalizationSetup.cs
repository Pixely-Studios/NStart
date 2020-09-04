using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

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

		public static void AddCustomLocalization(this IServiceCollection services)
		{
			if (services is null)
				throw new ArgumentNullException(nameof(services));

			services.Configure<RequestLocalizationOptions>(options =>
			{
				options.DefaultRequestCulture = new RequestCulture(culture: DefaultCulture, uiCulture: DefaultCulture);
				options.SupportedCultures = SupportedCultures;
				options.SupportedUICultures = SupportedCultures;
				options.RequestCultureProviders.Insert(0, new AcceptLanguageHeaderRequestCultureProvider());
				options.RequestCultureProviders.Insert(1, new CookieRequestCultureProvider());
			});

			services.AddLocalization(options => options.ResourcesPath = "Resources");
		}
	}
}
