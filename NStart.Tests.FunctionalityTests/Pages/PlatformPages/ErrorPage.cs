using Microsoft.AspNetCore.Mvc.RazorPages;
using NStart.Pages.Company;
using NStart.Pages.Platform;
using Xunit;

namespace NStart.Tests.FunctionalityTests.Pages.PlatformPages
{
	public class ErrorPage
	{
		[Fact]
		public void OnGet_RequestPage()
		{
			// Arrange
			ErrorPageModel pageModel = new ErrorPageModel();
			// Act
			var result = pageModel.Page();
			// Assert
			Assert.IsType<PageResult>(result);
		}
	}
}
