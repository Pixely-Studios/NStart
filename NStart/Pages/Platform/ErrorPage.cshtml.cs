using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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