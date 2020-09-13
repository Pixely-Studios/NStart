using Microsoft.AspNetCore.Mvc.RazorPages;
using NStart.Pages.Home;
using Xunit;

namespace NStart.Tests.FunctionalityTests.Pages.HomePages
{
	public class HomePage
	{
		[Fact]
		public void OnGet_RequestPage()
		{
			// Arrange
			HomePageModel pageModel = new HomePageModel();
			// Act
			var result = pageModel.Page();
			// Assert
			Assert.IsType<PageResult>(result);
		}
	}
}
