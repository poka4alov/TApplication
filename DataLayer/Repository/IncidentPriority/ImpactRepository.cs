using DataLayer.Model;
using ITILObjects.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
	public class ImpactRepository:IRepository<IImpact>
	{
		private ItsmDataContext _dataContext;

		public ImpactRepository(ItsmDataContext context)
		{
			this._dataContext = context;
		}

		public IImpact GetUrgencyById(int id)
		{

			return _dataContext.Impacts.Find(id);
		}

		public void Create(IImpact item)
		{
			Impact impact = new Impact() { Title = item.Title, Description = item.Description };
			_dataContext.Impacts.Add(impact);
		}

		public void Delete(int id)
		{
			_dataContext.Impacts.Remove(_dataContext.Impacts.Find(id));
		}

		public IImpact Get(int id)
		{
			return _dataContext.Impacts.Find(id);
		}


		public IEnumerable<IImpact> GetAll()
		{
				return _dataContext.Impacts.ToList();				
		}

		public void Update(IImpact item)
		{
			_dataContext.Entry(item).State = EntityState.Modified;
		}

		public async Task<IEnumerable<IImpact>> GetAllAsync()
		{
			return await _dataContext.Impacts.ToListAsync();
		}

		public async Task<IImpact> GetAsync(int id)
		{
			return await _dataContext.Impacts.FindAsync(id);
		}
	}
}
