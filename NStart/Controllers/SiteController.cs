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
			List<SyndicationItem> items = new();
			// Test all the Razor Pages from contact & featured media
			string contactUrl = Url.Page(Resources.Pages.Home.ContactPage.PageRoute, null, null, Request.Scheme);
			string mediaUrl = Url.Page(Resources.Pages.Home.MediaPage.PageRoute, null, null, Request.Scheme);
			// Add the pages to our Syndicated Feed Items
			items.Add(new SyndicationItem(Resources.Pages.Home.ContactPage.PageTitle, Resources.Pages.Home.ContactPage.PageDescription, new Uri(contactUrl!), Resources.Pages.Home.ContactPage.SyndicationId, DateTime.Now));
			items.Add(new SyndicationItem(Resources.Pages.Home.MediaPage.PageTitle, Resources.Pages.Home.MediaPage.PageDescription, new Uri(mediaUrl!), Resources.Pages.Home.MediaPage.SyndicationId, DateTime.Now));
			// Test all the Razor Pages for company
			string awardsUrl = Url.Page(Resources.Pages.Company.AwardsPage.PageRoute, null, null, Request.Scheme);
			string projectsUrl = Url.Page(Resources.Pages.Company.ProjectsPage.PageRoute, null, null, Request.Scheme);
			string teamsUrl = Url.Page(Resources.Pages.Company.TeamPage.PageRoute, null, null, Request.Scheme);
			// Add the pages to our Syndicated Feed Items
			items.Add(new SyndicationItem(Resources.Pages.Company.AwardsPage.PageTitle, Resources.Pages.Company.AwardsPage.PageDescription, new Uri(awardsUrl!), Resources.Pages.Company.AwardsPage.SyndicationId, DateTime.Now));
			items.Add(new SyndicationItem(Resources.Pages.Company.ProjectsPage.PageTitle, Resources.Pages.Company.ProjectsPage.PageDescription, new Uri(projectsUrl!), Resources.Pages.Company.ProjectsPage.SyndicationId, DateTime.Now));
			items.Add(new SyndicationItem(Resources.Pages.Company.TeamPage.PageTitle, Resources.Pages.Company.TeamPage.PageDescription, new Uri(teamsUrl!), Resources.Pages.Company.TeamPage.SyndicationId, DateTime.Now));

			// Use our Internal universal Feed to generate the Sitemap File
			MemoryStream resultFeed = await CreateAtomFeed(Resources.Controllers.SiteController.FeedName, Resources.Controllers.SiteController.FeedDescription, new Uri(Resources.Controllers.SiteController.FeedStartPage), Resources.Controllers.SiteController.FeedId, items).ConfigureAwait(false);

			// Return the generated universal Feed
			return File(resultFeed.ToArray(), Resources.Controllers.SiteController.FeedEncoding);
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
        private static async Task<MemoryStream> CreateAtomFeed(string feedTitle, string feedDescription, Uri feedAlternativeUri, string feedId, List<SyndicationItem> feedItems)
		{
			// Create the Cop
			TextSyndicationContent titleContent = new(feedTitle);
			TextSyndicationContent descriptionContent = new(feedDescription);
			TextSyndicationContent copyrightContent = new(string.Format(Resources.Controllers.SiteController.FeedCopyrightFormat, DateTime.Now, Resources.Controllers.SiteController.FeedCopyrightMessage));
		
			SyndicationFeed feed = new()
			{
				Id = feedId,
				Title = titleContent,
				Description = descriptionContent,
				BaseUri = feedAlternativeUri,
				Copyright = copyrightContent,
				LastUpdatedTime = DateTime.Now,
				Items = feedItems
			};

			XmlWriterSettings settings = new() 
			{
				Encoding = Encoding.UTF8,
				NewLineHandling = NewLineHandling.Entitize,
				NewLineOnAttributes = true,
				Indent = true,
				Async = true
			};

			MemoryStream stream = new();
			await using XmlWriter xmlWriter = XmlWriter.Create(stream, settings);

			Rss20FeedFormatter rssFormatter = new(feed, false);
			rssFormatter.WriteTo(xmlWriter);
			await xmlWriter.FlushAsync().ConfigureAwait(false);

			return stream;
		}
	}
}
