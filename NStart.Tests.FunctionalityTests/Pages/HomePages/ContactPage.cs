using Microsoft.AspNetCore.Mvc.RazorPages;
using NStart.Pages.Home;
using Xunit;

namespace NStart.Tests.FunctionalityTests.Pages.HomePages
{
	public class ContactPage
	{
		[Fact]
		public void OnGet_RequestPage()
		{
			// Arrange
			ContactPageModel pageModel = new ContactPageModel();
			// Act
			var result = pageModel.Page();
			// Assert
			Assert.IsType<PageResult>(result);
		}
	}
}
