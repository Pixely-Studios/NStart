using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Mvc;

namespace NStart.Controllers
{
	public class SiteController : Controller
	{
		/// <summary>
		/// This is a Generic (and very manual, please automate this for your own sanity) implementation of a dynamic Atom Sitemap implementation
		/// </summary>
		/// <returns>A generated Atom Sitemap</returns>
		[HttpGet]
		[Route("/sitemap.xml")]
		[ResponseCache(Duration = 5000)]
		public async Task<IActionResult> GenerateSitemapAsync()
		{
			// Create a empty default container for our Syndicated Feed Items
			var items = new List<SyndicationItem>();
			// Test all the Razor Pages from contact & featured media
			var contactUrl = Url.Page("/Home/ContactPage", null, null, Request.Scheme);
			var mediaUrl = Url.Page("/Home/MediaPage", null, null, Request.Scheme);
			// Add the pages to our Syndicated Feed Items
			items.Add(new SyndicationItem("Contact Page", "NStart's default contact page", new Uri(contactUrl), "2", DateTime.Now));
			items.Add(new SyndicationItem("Media Page", "NStart's default selected media page", new Uri(mediaUrl), "3", DateTime.Now));
			// Test all the Razor Pages for company
			var awardsUrl = Url.Page("/Company/AwardsPage", null, null, Request.Scheme);
			var projectsUrl = Url.Page("/Company/ProjectsPage", null, null, Request.Scheme);
			var teamsUrl = Url.Page("/Company/TeamPage", null, null, Request.Scheme);
			// Add the pages to our Syndicated Feed Items
			items.Add(new SyndicationItem("Awards Page", "NStart's default awards page", new Uri(awardsUrl), "4", DateTime.Now));
			items.Add(new SyndicationItem("Projects Page", "NStart's default projects page", new Uri(projectsUrl), "5", DateTime.Now));
			items.Add(new SyndicationItem("Team Page", "NStart's default team page", new Uri(teamsUrl), "6", DateTime.Now));
			// Use our Internal universal Feed to generate the Sitemap File
			var resultFeed = await CreateAtomFeed("NStart XML Feed", "The default XML Sitemap feed for a NStart Instance", new Uri("https://nstart.com"), "1", items).ConfigureAwait(false);
			// Return the generated universal Feed
			return File(resultFeed.ToArray(), "application/rss+xml; charset=utf-8");
		}

		/// <summary>
		/// Generates a Atom Feed to be used as a Sitemap
		/// </summary>
		/// <param name="feedTitle">Title of the Feed</param>
		/// <param name="feedDescription">Description of the Feed</param>
		/// <param name="feedAlternativeUri">URI of the root of the Feed</param>
		/// <param name="feedId">ID of the feed</param>
		/// <param name="feedItems">Items contained in the feed to be syndicated</param>
		/// <returns>A MemoryStream conformed of a generated Sitemap Atom Feed</returns>
		internal static async Task<MemoryStream> CreateAtomFeed(string feedTitle, string feedDescription, Uri feedAlternativeUri, string feedId, List<SyndicationItem> feedItems)
		{
			var feed = new SyndicationFeed(feedTitle, feedDescription, feedAlternativeUri, feedId, DateTime.Now)
			{
				Copyright = new TextSyndicationContent($"{DateTime.Now.Year} NStart Default Instance"),
			};

			feed.Items = feedItems;

			var settings = new XmlWriterSettings
			{
				Encoding = Encoding.UTF8,
				NewLineHandling = NewLineHandling.Entitize,
				NewLineOnAttributes = true,
				Indent = true,
				Async = true
			};

			using var stream = new MemoryStream();

			using var xmlWriter = XmlWriter.Create(stream, settings);

			var rssFormatter = new Rss20FeedFormatter(feed, false);
			rssFormatter.WriteTo(xmlWriter);
			await xmlWriter.FlushAsync().ConfigureAwait(false);

			return stream;
		}
	}
}
