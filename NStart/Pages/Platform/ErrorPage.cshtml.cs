using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NStart.Pages.Platform
{
	public class ErrorPageModel : PageModel
	{
		/// <summary>
		/// Custom response of a GET request to the Error page
		/// </summary>
		/// <param name="code">3 digits code of a HTTP error</param>
		public void OnGet(int code)
		{
			// Add to our ViewData dictionary the Error Code under a Code identifier
			ViewData.Add("Code", code);
			// Return the page
			Page();
		}
	}
}