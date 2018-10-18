using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ItsmCore.Services.Settings;
using AutoMapper;
using ITILObjects.Model;
using WebPortal.Models.Settings;
using System.Threading.Tasks;

namespace WebPortal.Controllers.Settings
{
    public class IncidentPriorityController : Controller
    {
		private IncidentPriorityService _service;
	

		public IncidentPriorityController()
		{
			_service = new IncidentPriorityService();
			
		}
		// GET: IncidentPriorit
		[Authorize]
		public ActionResult Index()
        {
            return View();
        }

		// GET: IncidentPriority/Details/5
		[Authorize]
		public ActionResult Details(int id)
        {
			IIncidentPriority _incidentPriority = _service.GetIncidentPriorityById(id);
			string str = _incidentPriority.IncidentImpact.Description;
			string strs= _incidentPriority.IncidentUrgency.Title;
			var _incidentPriorityModel = Mapper.Map<IIncidentPriority, IncidentPriorityDetailModel>(_incidentPriority,
				opt => opt.ConfigureMap()
					.ForMember(dest => dest.ResolutionTime, m => m.MapFrom(src => src.ResolutionTime))
					.ForMember(dest => dest.ResponceTime, m => m.MapFrom(src => src.ResponceTime))
					.ForMember(dest => dest.Description, m => m.MapFrom(src => src.Description))
					.ForMember(dest => dest.Title, m => m.MapFrom(src => src.Title))
					.ForMember(dest => dest.ImpactTitle, m=>m.MapFrom(src=>src.IncidentImpact.Title))
					.ForMember(dest => dest.UrgencyTitle, m => m.MapFrom(src => src.IncidentUrgency.Title))
					
				);
			return View(_incidentPriorityModel);
        }

		// GET: IncidentPriority/Create
		[Authorize]
		public ActionResult Create()
        {
			IncidentPriorityModel _model = new IncidentPriorityModel();
			_model.ImpactsList = _service.GetImpacts();
			_model.UrgenciesList = _service.GetUrgencies();
            return View(_model);
        }

		

		// POST: IncidentPriority/Create
		[HttpPost]
		[Authorize]
		public ActionResult Create(IncidentPriorityModel incidentPriorytyModel)
        {
            try
            {
				IIncidentPriority _incidentPriority = Mapper.Map<IncidentPriorityModel, IIncidentPriority>(incidentPriorytyModel,
					opt => opt.ConfigureMap()
					.ForMember(dest=>dest.ResolutionTime,m=>m.MapFrom(src=>src.ResolutionTime))
					.ForMember(dest => dest.ResponceTime, m => m.MapFrom(src => src.ResponceTime))
					.ForMember(dest => dest.Description, m => m.MapFrom(src => src.Description))
					.ForMember(dest => dest.Title, m => m.MapFrom(src => src.Title))
					.ForMember(dest=>dest.IncidentImpact, m=>m.Ignore())
					.ForMember(dest=>dest.IncidentUrgency, m => m.Ignore()));

				_incidentPriority.IncidentImpact = _service.GetImpactById(incidentPriorytyModel.ImpactId);
				_incidentPriority.IncidentUrgency = _service.GetUrgencyById(incidentPriorytyModel.UrgencyId);
				_service.CreateIncidentPriority(_incidentPriority);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

		// GET: IncidentPriority/Edit/5
		[Authorize]
		public ActionResult Edit(int id)
        {
			IIncidentPriority _incidentPriority = _service.GetIncidentPriorityById(id);
			var _incidentPriorityModel = Mapper.Map<IIncidentPriority, IncidentPriorityModel>(_incidentPriority,
				opt=>opt.ConfigureMap()
				.ForMember(dest => dest.Title, m => m.MapFrom(src => src.Title))
				.ForMember(dest => dest.Description, m => m.MapFrom(src => src.Description))
				.ForMember(dest => dest.ResolutionTime, m => m.MapFrom(src => src.ResolutionTime))
				.ForMember(dest => dest.ResponceTime, m => m.MapFrom(src => src.ResponceTime))
				.ForMember(dest => dest.ImpactId, m => m.MapFrom(src => src.IncidentImpact.Id))
				.ForMember(dest => dest.UrgencyId, m => m.MapFrom(src => src.IncidentUrgency.Id))
				.ForMember(dest => dest.ImpactsList, m => m.Ignore())
				.ForMember(dest => dest.UrgenciesList, m => m.Ignore())
				);
			_incidentPriorityModel.UrgenciesList =  _service.GetUrgencies();
			_incidentPriorityModel.ImpactsList = _service.GetImpacts();
			return View(_incidentPriorityModel);
		}

        // POST: IncidentPriority/Edit/5
        [HttpPost]
		[Authorize]
		public ActionResult Edit(int id, IncidentPriorityModel incidentPriorytyModel)
        {
			try
			{
				IIncidentPriority _incidentPriority = _service.GetIncidentPriorityById(id);
				_incidentPriority.Title = incidentPriorytyModel.Title;
				_incidentPriority.Description = incidentPriorytyModel.Description;
				_incidentPriority.ResolutionTime = incidentPriorytyModel.ResolutionTime;
				_incidentPriority.ResponceTime = incidentPriorytyModel.ResponceTime;
				_incidentPriority.IncidentImpact = _service.GetImpactById(incidentPriorytyModel.ImpactId);
				_incidentPriority.IncidentUrgency = _service.GetUrgencyById(incidentPriorytyModel.UrgencyId);
				_service.UpdateIncidentPriority(_incidentPriority);
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
        }

		// GET: IncidentPriority/Delete/5
		[Authorize]
		public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IncidentPriority/Delete/5
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

		public async Task<JsonResult> GetJsonIncidentPriorities()
		{
			List<IncidentPriorityDetailModel> urgencyModels = new List<IncidentPriorityDetailModel>();
			IEnumerable<IIncidentPriority> incidentPriorities = await _service.GetIncidentPrioritiesAsync();
			foreach (IIncidentPriority val in incidentPriorities)
			{
				urgencyModels.Add(Mapper.Map<IIncidentPriority, IncidentPriorityDetailModel>(val,
					opt => opt.ConfigureMap()
					.ForMember(dest => dest.ResolutionTime, m => m.MapFrom(src => src.ResolutionTime))
					.ForMember(dest => dest.ResponceTime, m => m.MapFrom(src => src.ResponceTime))
					.ForMember(dest => dest.Description, m => m.MapFrom(src => src.Description))
					.ForMember(dest => dest.Title, m => m.MapFrom(src => src.Title))
					.ForMember(dest => dest.ImpactTitle, m => m.MapFrom(src => src.IncidentImpact.Title))
					.ForMember(dest => dest.UrgencyTitle, m => m.MapFrom(src => src.IncidentUrgency.Title)))
					);
			}
			return Json(urgencyModels, JsonRequestBehavior.AllowGet);
		}
    }
}
