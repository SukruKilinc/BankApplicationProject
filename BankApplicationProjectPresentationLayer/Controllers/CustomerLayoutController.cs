using Microsoft.AspNetCore.Mvc;

namespace BankApplicationProjectPresentationLayer.Controllers
{
	public class CustomerLayoutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
