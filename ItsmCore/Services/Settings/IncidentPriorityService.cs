using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITILObjects.Model;
using DataLayer;


namespace ItsmCore.Services.Settings
{
	public class IncidentPriorityService
	{
		UnitOfWork _unitOfWork;

		public IncidentPriorityService()
		{
			_unitOfWork = new UnitOfWork();
		}
		#region // Incident Priority
		public IIncidentPriority GetIncidentPriorityById(int id)
		{
			IIncidentPriority priority = _unitOfWork.IncidentPriority.Get(id);
			return _unitOfWork.IncidentPriority.Get(id);
		}

		public IEnumerable<IIncidentPriority> GetIncidentPriority()
		{
			return _unitOfWork.IncidentPriority.GetAll();
		}

		public async Task<IEnumerable<IIncidentPriority>> GetIncidentPrioritiesAsync()
		{
			return await _unitOfWork.IncidentPriority.GetAllAsync();
		}

		public void CreateIncidentPriority(IIncidentPriority incidentPriority)
		{
			_unitOfWork.IncidentPriority.Create(incidentPriority);
			_unitOfWork.Save();
		}

		public void DeleteIncidentPriority(int id)
		{
			_unitOfWork.IncidentPriority.Delete(id);
			_unitOfWork.Save();
		}

		public void UpdateIncidentPriority(IIncidentPriority incidentPriority)
		{
			
_unitOfWork.IncidentPriority.Update(incidentPriority);
			_unitOfWork.Save();
		}

		#endregion

		#region // Urgency
		public IUrgency GetUrgencyById(int id)
		{

			return _unitOfWork.Urgency.Get(id);
		}

		public IEnumerable<IUrgency> GetUrgencies()
		{
			return _unitOfWork.Urgency.GetAll();
		}

		public async Task<IEnumerable<IUrgency>> GetUrgenciesAsync()
		{
			return await _unitOfWork.Urgency.GetAllAsync();
		}



		public void CreateUrgency(IUrgency urgency)
		{
			_unitOfWork.Urgency.Create(urgency);
			_unitOfWork.Save();
		}

		public void DeleteUrgency(int id)
		{
			_unitOfWork.Urgency.Delete(id);
			_unitOfWork.Save();
		}

		public void UpdateUrgency(IUrgency urgency)
		{
			_unitOfWork.Urgency.Update(urgency);
			_unitOfWork.Save();
		}
		#endregion

		#region //Impact
		public IImpact GetImpactById(int id)
		{
			return _unitOfWork.Impact.Get(id);
		}

		public IEnumerable<IImpact> GetImpacts()
		{
			return _unitOfWork.Impact.GetAll();
		}

		public async Task<IEnumerable<IImpact>> GetImpactsAsync()
		{
			return await _unitOfWork.Impact.GetAllAsync();
		}

		public void CreateImpact(IImpact impact)
		{
			_unitOfWork.Impact.Create(impact);
			_unitOfWork.Save();
		}

		public void DeleteImpact(int id)
		{
			_unitOfWork.Impact.Delete(id);
			_unitOfWork.Save();
		}

		public void UpdateImpact(IImpact impact)
		{
			_unitOfWork.Impact.Update(impact);
			_unitOfWork.Save();
		}

		#endregion

	}

}
