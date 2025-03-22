using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.RentACarFilterViewComponents
{
	public class _RentACarFilterComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke(string v)
		{
			TempData["value"] = v;
			return View();
		}
	}
}
