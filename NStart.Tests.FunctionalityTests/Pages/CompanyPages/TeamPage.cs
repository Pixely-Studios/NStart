using Microsoft.AspNetCore.Mvc.RazorPages;
using NStart.Pages.Company;
using NStart.Pages.Home;
using Xunit;

namespace NStart.Tests.FunctionalityTests.Pages.CompanyPages
{
	public class TeamPage
	{
		[Fact]
		public void OnGet_RequestPage()
		{
			// Arrange
			TeamPageModel pageModel = new TeamPageModel();
			// Act
			var result = pageModel.Page();
			// Assert
			Assert.IsType<PageResult>(result);
		}
	}
}
