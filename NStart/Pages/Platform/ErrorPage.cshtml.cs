using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NStart.Pages.Platform
{
	public class ErrorPageModel : PageModel
	{
		public void OnGet(int code)
		{
			ViewData.Add("Code", code);

			Page();
		}
	}
}