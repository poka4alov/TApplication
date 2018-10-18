using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPortal.Models.Settings;
using ITILObjects.Model;
using AutoMapper;
using ItsmCore.Services.Settings;
using System.Threading.Tasks;

namespace WebPortal.Controllers.Settings
{
    public class ImpactController : Controller
    {
		IncidentPriorityService _service;
		public ImpactController()
		{
			_service = new IncidentPriorityService();
		}
		// GET: Impact
		[Authorize]
		public ActionResult Index()
        {
            return View();
        }

		// GET: Impact/Details/5
		[Authorize]
		public ActionResult Details(int id)
        {
			IImpact _impact = _service.GetImpactById(id);
			var _impactModel = Mapper.Map<IImpact, ImpactModel>(_impact);
			return View(_impactModel);
        }

		// GET: Impact/Create
		[Authorize]
		public ActionResult Create()
        {
            return View();
        }

        // POST: Impact/Create
        [HttpPost]
		[Authorize]
		public ActionResult Create(FormCollection collection)
        {
            try
            {
				ImpactModel impactModel = new ImpactModel();
				TryUpdateModel(impactModel, collection);

				var impact = Mapper.Map<ImpactModel, IImpact>(impactModel);
				_service.CreateImpact(impact);
				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

		// GET: Impact/Edit/5
		[Authorize]
		public ActionResult Edit(int id)
        {
			IImpact _impact = _service.GetImpactById(id);
			var _impactModel = Mapper.Map<IImpact, ImpactModel>(_impact);
			return View(_impactModel);
        }

        // POST: Impact/Edit/5
        [HttpPost]
		[Authorize]
		public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
				IImpact _impact = _service.GetImpactById(id);

				TryUpdateModel(_impact, collection);
				_service.UpdateImpact(_impact);

				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

		// GET: Impact/Delete/5
		[Authorize]
		public ActionResult Delete(int id)
        {
			IImpact _impact = _service.GetImpactById(id);
			var _impactModel = Mapper.Map<IImpact, ImpactModel>(_impact);
			if (_impactModel!=null)return PartialView(_impactModel);
			return HttpNotFound();
		}

        // POST: Impact/Delete/5
        [HttpPost]
		[Authorize]
		public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
				_service.DeleteImpact(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

		public async Task<JsonResult> GetJsonImpacts()
		{
			List<ImpactModel> _urgencyModels = new List<ImpactModel>();
			IEnumerable<IImpact> _impacts = await _service.GetImpactsAsync();
			foreach (IImpact val in _impacts)
			{
				_urgencyModels.Add(Mapper.Map<IImpact, ImpactModel>(val));
			}
			return Json(_urgencyModels, JsonRequestBehavior.AllowGet);
		}
	}
}
