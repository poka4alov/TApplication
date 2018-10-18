using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ITILObjects.Model;
using ItsmCore.Services.Settings;

using WebPortal.Models.Settings;

namespace WebPortal.Controllers.Settings
{
    public class UrgencyController : Controller
    {
		IncidentPriorityService _service;
		
		public UrgencyController()
		{
			_service = new IncidentPriorityService();
		}


		// GET: Urgency
		[Authorize]
		public ActionResult Index()
        {
            return View();
        }

		// GET: Urgency/Details/5
		[Authorize]
		public ActionResult Details(int id)
        {
			IUrgency urgency = _service.GetUrgencyById(id);
			var urgenc = Mapper.Map<IUrgency, UrgencyModel>(urgency);
			return View(urgenc);
        }

		// GET: Urgency/Create
		[Authorize]
		public ActionResult Create()
        {
            return View();
        }

        // POST: Urgency/Create
        [HttpPost]
		[Authorize]
		public ActionResult Create(FormCollection collection)
        {
            try
            {
				// TODO: Add insert logic here
				UrgencyModel urgencyModel = new UrgencyModel();
				TryUpdateModel(urgencyModel, collection);

				var urgency = Mapper.Map<UrgencyModel, IUrgency>(urgencyModel);
				_service.CreateUrgency(urgency);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

		// GET: Urgency/Edit/5
		[Authorize]
		public ActionResult Edit(int id)
        {

			IUrgency _urgency = _service.GetUrgencyById(id);
			var _urgencyModel = Mapper.Map<IUrgency, UrgencyModel>(_urgency);
			return View(_urgencyModel);
			
        }

        // POST: Urgency/Edit/5
        [HttpPost]
		[Authorize]
		public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
				IUrgency _urgency = _service.GetUrgencyById(id);

				TryUpdateModel(_urgency, collection);
				_service.UpdateUrgency(_urgency);
				return RedirectToAction("Index");
				
            }
            catch
            {
                return View();
            }
        }

		// GET: Urgency/Delete/5
		[Authorize]
		public ActionResult Delete(int id)
        {
			IUrgency urgency = _service.GetUrgencyById(id);
			var urgenc = Mapper.Map<IUrgency, UrgencyModel>(urgency);
			if (urgenc != null)
				return PartialView(urgenc);
			return HttpNotFound();
        }

        // POST: Urgency/Delete/5
        [HttpPost]
		[Authorize]
		public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
				_service.DeleteUrgency(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

		public async Task<JsonResult> GetJsonUrgents()
		{
			List<UrgencyModel> urgencyModels = new List<UrgencyModel>();
			IEnumerable<IUrgency> urgencies = await _service.GetUrgenciesAsync();
			foreach (IUrgency val in urgencies)
			{
				urgencyModels.Add(Mapper.Map<IUrgency, UrgencyModel>(val));
			}
			return Json(urgencyModels, JsonRequestBehavior.AllowGet);
		}
    }
}
