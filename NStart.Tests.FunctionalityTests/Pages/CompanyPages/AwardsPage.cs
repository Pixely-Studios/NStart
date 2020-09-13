using Microsoft.AspNetCore.Mvc.RazorPages;
using NStart.Pages.Company;
using Xunit;

namespace NStart.Tests.FunctionalityTests.Pages.CompanyPages
{
	public class AwardsPage
	{
		[Fact]
		public void OnGet_RequestPage()
		{
			// Arrange
			AwardsPageModel pageModel = new AwardsPageModel();
			// Act
			var result = pageModel.Page();
			// Assert
			Assert.IsType<PageResult>(result);
		}
	}
}
