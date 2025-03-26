using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
	public class AdminDashboardController : Controller
	{
		[Area("Admin")]
		[Route("Admin/[controller]/[action]/{id?}")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
