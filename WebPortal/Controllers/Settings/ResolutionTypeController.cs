using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ItsmCore.Services.Settings;
using ITILObjects.Model;
using WebPortal.Models.Settings;
using AutoMapper;
using System.Threading.Tasks;

namespace WebPortal.Controllers.Settings
{
    public class ResolutionTypeController : Controller
    {
		ClosureDataService _service;
		public ResolutionTypeController()
		{
			_service = new ClosureDataService();

		}
		// GET: ResolutionType
		[Authorize]
		public ActionResult Index()
        {
            return View();
        }

		// GET: ResolutionType/Details/5
		[Authorize]
		public ActionResult Details(int id)
        {
			IResolutionType resolutionType = _service.GetResolutionById(id);
			var _resolutionModel = Mapper.Map<IResolutionType,ResolutionTypeModel >(resolutionType);
			return View(_resolutionModel);
		}

		// GET: ResolutionType/Create
		[Authorize]
		public ActionResult Create()
        {
            return View();
        }

        // POST: ResolutionType/Create
        [HttpPost]
		[Authorize]
		public ActionResult Create(ResolutionTypeModel resolutionTypeModel)
        {
            try
            {
				var _resolutionModel = Mapper.Map<ResolutionTypeModel, IResolutionType>(resolutionTypeModel);
				_service.UpdateResolutionType(_resolutionModel);
				return RedirectToAction("Index");
			}
            catch
            {
                return View();
            }
        }

		// GET: ResolutionType/Edit/5
		[Authorize]
		public ActionResult Edit(int id)
        {
			IResolutionType resolutionType = _service.GetResolutionById(id);
			var _resolutionModel = Mapper.Map<IResolutionType, ResolutionTypeModel>(resolutionType);
			return View(_resolutionModel);
		}

        // POST: ResolutionType/Edit/5
        [HttpPost]
		[Authorize]
		public ActionResult Edit(int id, ResolutionTypeModel resolutionTypeModel)
        {
            try
            {
				var _resolutionModel = Mapper.Map<ResolutionTypeModel, IResolutionType>(resolutionTypeModel);
				_service.UpdateResolutionType(_resolutionModel);
				return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

		// GET: ResolutionType/Delete/5
		[Authorize]
		public ActionResult Delete(int id)
        {
			IResolutionType resolutionType = _service.GetResolutionById(id);
			var _resolutionModel = Mapper.Map<IResolutionType, ResolutionTypeModel>(resolutionType);
			return PartialView(_resolutionModel);
		}

        // POST: ResolutionType/Delete/5
        [HttpPost]
		[Authorize]
		public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
				_service.DeleteResolutionType(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

		public async Task<JsonResult> GetJsonResolutionTypes()
		{
			List<ResolutionTypeModel> urgencyModels = new List<ResolutionTypeModel>();
			IEnumerable<IResolutionType> urgencies = await _service.GetResolutionTypesAsync();
			foreach (IResolutionType val in urgencies)
			{
				urgencyModels.Add(Mapper.Map<IResolutionType, ResolutionTypeModel>(val));
			}
			return Json(urgencyModels, JsonRequestBehavior.AllowGet);
		}
	}
}
