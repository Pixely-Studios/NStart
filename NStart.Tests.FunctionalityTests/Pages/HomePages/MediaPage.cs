using Microsoft.AspNetCore.Mvc.RazorPages;
using NStart.Pages.Company;
using NStart.Pages.Home;
using Xunit;

namespace NStart.Tests.FunctionalityTests.Pages.HomePages
{
	public class MediaPage
	{
		[Fact]
		public void OnGet_RequestPage()
		{
			// Arrange
			MediaPageModel pageModel = new MediaPageModel();
			// Act
			var result = pageModel.Page();
			// Assert
			Assert.IsType<PageResult>(result);
		}
	}
}