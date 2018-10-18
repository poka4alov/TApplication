using DataLayer.Model;
using ITILObjects.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
	public class IncidentPriorityRepository:IRepository<IIncidentPriority>
	{
		private ItsmDataContext _dataContext;

		public IncidentPriorityRepository(ItsmDataContext context)
		{
			this._dataContext = context;
		}

		public IIncidentPriority GetUrgencyById(int id)
		{
			return _dataContext.IncidentPriorities.Find(id);
		}

		public void Create(IIncidentPriority item)
		{
			IncidentPriority _incidentPriority = new IncidentPriority()
			{
				Title = item.Title,
				Description = item.Description,
				Impact = (Impact)item.IncidentImpact,
				Urgency= (Urgency)item.IncidentUrgency,
				ResolutionTime = item.ResolutionTime,
				ResponceTime = item.ResponceTime
			};
			_dataContext.IncidentPriorities.Add(_incidentPriority);
		}

		public void Delete(int id)
		{
			_dataContext.IncidentPriorities.Remove(_dataContext.IncidentPriorities.Find(id));
		}

		public IIncidentPriority Get(int id)
		{
			return _dataContext.IncidentPriorities.Find(id);
		}

		public IEnumerable<IIncidentPriority> GetAll()
		{
			return _dataContext.IncidentPriorities;
		}

		public void Update(IIncidentPriority item)
		{
			_dataContext.Entry(item).State = EntityState.Modified;
		}

		public async Task<IEnumerable<IIncidentPriority>> GetAllAsync()
		{
			return await _dataContext.IncidentPriorities.ToListAsync();
		}

		public async Task<IIncidentPriority> GetAsync(int id)
		{
			return	await _dataContext.IncidentPriorities.FindAsync(id);	
		}

	}
}
