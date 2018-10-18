using DataLayer.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ITILObjects.Model;
using System;

namespace DataLayer.Repository
{
	public class IncidentRepository : IRepository<IIncident>
	{
		ItsmDataContext _dataContext;
		public IncidentRepository(ItsmDataContext dataContext)
		{
			_dataContext = dataContext;
		}
		public void Create(IIncident item)
		{
			Incident _incident = new Incident()
			{
				Title = item.Title,
				Description = item.Description,
				IncidentPriority = item.IncidentPriority,
				Owner = item.Owner,
				ServiceDescAgent = item.ServiceDescAgent,
				CallbackMethod = item.CallbackMethod,
				NotificationMethod = item.NotificationMethod,
				OrderDate = DateTime.Now,
			};
			_dataContext.Incidents.Add(_incident);
		}

		public IIncident Get(int id)
		{
			return _dataContext.Incidents.Find(id);
		}

		public IEnumerable<IIncident> GetAll()
		{
			return _dataContext.Incidents.ToList();
		}

		public async Task<IEnumerable<IIncident>> GetAllAsync()
		{
			return await _dataContext.Incidents.ToListAsync();
		}

		public Task<IIncident> GetAsync(int id)
		{
			throw new NotImplementedException();
		}

		public void Update(IIncident item)
		{
			_dataContext.Entry(item).State = EntityState.Modified;
		}
		public void Delete(int id)
		{
			_dataContext.Incidents.Remove(_dataContext.Incidents.Find(id));
		}

	}
}
