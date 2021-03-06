﻿using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;

namespace NStart.Extensions
{
	public static class LocalizationSetup
	{
		// Default UI Culture
		internal static readonly string DefaultCulture = Resources.Application.LocalizationExtension.Culture_English_US;
		// List of supported cultures for Localization & Globalization
		internal static readonly CultureInfo[] SupportedCultures =
		{
			// Deutsch
			new CultureInfo(Resources.Application.LocalizationExtension.Culture_German),
			// English
			new CultureInfo(Resources.Application.LocalizationExtension.Culture_English),
			// English - US
			new CultureInfo(Resources.Application.LocalizationExtension.Culture_English_US),
			// Español
			new CultureInfo(Resources.Application.LocalizationExtension.Culture_Spanish),
			// Français
			new CultureInfo(Resources.Application.LocalizationExtension.Culture_French),
			// Italiano
			new CultureInfo(Resources.Application.LocalizationExtension.Culture_Italian),
			// 日本 - Japanese
			new CultureInfo(Resources.Application.LocalizationExtension.Culture_Japanese),
			// 한국어 - Korean
			new CultureInfo(Resources.Application.LocalizationExtension.Culture_Korean),
			// Português
			new CultureInfo(Resources.Application.LocalizationExtension.Culture_Portugese),
			// русский - Russian
			new CultureInfo(Resources.Application.LocalizationExtension.Culture_Russian)
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
			services.AddLocalization(options => options.ResourcesPath = Resources.Application.LocalizationExtension.ResourcesPath);
		}
	}
}
