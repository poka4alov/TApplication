﻿using System.Web.Mvc;

namespace WebPortal.Controllers
{
	public class ErrorController : Controller
	{
		public ActionResult InternalServerError()
		{
			return View();
		}

		public ActionResult NotFound()
		{
			return View();
		}
	}
}
