using ITILObjects.Model;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebPortal.Controllers
{
	public class IncidentsController : Controller
    {
		// GET: Incidents
		[Authorize]
		public ActionResult Index()
        {
            return View();
        }
		[Authorize]
		public ActionResult Incidents()
		{
			return View();
		}

		// GET: Incident/Details/5
		[Authorize]
		public ActionResult Details(int id)
		{
			
			return View();
		}

		// GET: Incident/Create
		[Authorize]
		public ActionResult Create()
		{
			return View();
		}

		// POST: Incident/Create
		[HttpPost]
		[Authorize]
		public ActionResult Create(FormCollection collection)
		{
			try
			{
				// TODO: Add insert logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Incident/Edit/5
		[Authorize]
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: Incident/Edit/5
		[HttpPost]
		[Authorize]
		public ActionResult Edit(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add update logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		// GET: Incident/Delete/5
		[Authorize]
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: Incident/Delete/5
		[HttpPost]
		[Authorize]
		public ActionResult Delete(int id, FormCollection collection)
		{
			try
			{
				// TODO: Add delete logic here

				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}

		/// <summary>
		/// JSON CONTROLLERS
		/// </summary>
		/// <returns></returns>
		/// 
		[Authorize]
		public JsonResult GetIncidents()
		{
			List<IIncident> model = new List<IIncident>();
			int i = 0;
			while (i != 1000)
			{
			
				
			}
			
			
			return  Json(model, JsonRequestBehavior.AllowGet);
		}
    }

}