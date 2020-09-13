using Microsoft.AspNetCore.Mvc.RazorPages;
using NStart.Pages.Company;
using Xunit;

namespace NStart.Tests.FunctionalityTests.Pages.CompanyPages
{
	public class ProjectsPage
	{
		[Fact]
		public void OnGet_RequestPage()
		{
			// Arrange
			ProjectsPageModel pageModel = new ProjectsPageModel();
			// Act
			var result = pageModel.Page();
			// Assert
			Assert.IsType<PageResult>(result);
		}
	}
}
