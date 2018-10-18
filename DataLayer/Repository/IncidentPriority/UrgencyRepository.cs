using DataLayer.Model;
using ITILObjects.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
	public class UrgencyRepository: IRepository<IUrgency>
	{
		private ItsmDataContext _dataContext;

		public UrgencyRepository(ItsmDataContext context)
		{
			this._dataContext = context;
		}

		public  IUrgency GetUrgencyById(int id)
		{
			return _dataContext.Urgencies.Find(id);
		}

		public void Create(IUrgency item)
		{
			Urgency urgency = new Urgency() { Title=item.Title,Description=item.Description};
			_dataContext.Urgencies.Add(urgency);
		}

		public void Delete(int id)
		{
			_dataContext.Urgencies.Remove(_dataContext.Urgencies.Find(id));
		}

		public IUrgency Get(int id)
		{
			return _dataContext.Urgencies.Find(id);
		}

		public IEnumerable<IUrgency> GetAll()
		{
				return _dataContext.Urgencies.ToList();				
		}

		public void Update(IUrgency item)
		{
			_dataContext.Entry(item).State = EntityState.Modified;
		}

		public async Task<IEnumerable<IUrgency>> GetAllAsync()
		{
			return await _dataContext.Urgencies.ToListAsync();
		}

		public async Task<IUrgency> GetAsync(int id)
		{
			return await _dataContext.Urgencies.FindAsync(id);
		}
	}
}
