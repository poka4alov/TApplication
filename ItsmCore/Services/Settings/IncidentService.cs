using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using ITILObjects.Model;

namespace ItsmCore.Services.Settings
{
	class IncidentService
	{
		private UnitOfWork _unitOfWork;
		public IncidentService()
		{
			_unitOfWork = new UnitOfWork();
		}

		#region // Method of notification
		public IMethodOfNotification GetMethodOfNotificationById(int id)
		{
			return _unitOfWork.MethodOfNotification.Get(id);
		}
		public IEnumerable<IMethodOfNotification> GetMethodOfNotifications()
		{
			return _unitOfWork.MethodOfNotification.GetAll();
		}
		public async Task<IEnumerable<IMethodOfNotification>> GetMethodOfNotificationsAsync()
		{
			return await _unitOfWork.MethodOfNotification.GetAllAsync();
		}
		public void CreateMethodOfNotification(IMethodOfNotification methodOfNotification)
		{
			_unitOfWork.MethodOfNotification.Create(methodOfNotification);
			_unitOfWork.Save();
		}
		public void DeleteMethodOfNotification(int id)
		{
			_unitOfWork.MethodOfNotification.Delete(id);
			_unitOfWork.Save();
		}
		public void UpdateMethodOfNotification(IMethodOfNotification item)
		{
			_unitOfWork.MethodOfNotification.Update(item);
			_unitOfWork.Save();
		}

		#endregion
		#region //Incidents
		public IIncident GetIncidentById(int id)
		{

			return _unitOfWork.Incident.Get(id);
		}

		public IEnumerable<IIncident> GetIncidents()
		{
			return _unitOfWork.Incident.GetAll();
		}

		public async Task<IEnumerable<IIncident>> GetIncidentsAsync()
		{
			return await _unitOfWork.Incident.GetAllAsync();
		}

		public void CreateIncidentPriority(IIncidentPriority incidentPriority)
		{
			_unitOfWork.IncidentPriority.Create(incidentPriority);
			_unitOfWork.Save();
		}

		public void DeleteIncident(int id)
		{
			_unitOfWork.Incident.Delete(id);
			_unitOfWork.Save();
		}

		public void UpdateIncident(IIncident incident)
		{

			_unitOfWork.Incident.Update(incident);
			_unitOfWork.Save();
		}
		#endregion
	}
}
