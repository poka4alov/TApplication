using System.Web.Mvc;

namespace WebPortal.Controllers
{
	public class HomeController : Controller
	{
		[Authorize]
		public ActionResult Index()
		{
			return View();
		}
		[Authorize]
		public ActionResult AnotherLink()
		{
			return View("Index");
		}
	}
}
