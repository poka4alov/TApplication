using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITILObjects.Model;
using DataLayer.Model;
using System.Data.Entity;

namespace DataLayer.Repository.ClosureData
{
	public class ResolutionTypeRepository : IRepository<IResolutionType>
	{
		private ItsmDataContext _dataContext;
		public ResolutionTypeRepository(ItsmDataContext dataContext)
		{
			_dataContext = dataContext;
		}
		public void Create(IResolutionType item)
		{
			_dataContext.ResolutionTypes.Add((ResolutionType)item);
		}

		public void Delete(int id)
		{
			_dataContext.ResolutionTypes.Remove(_dataContext.ResolutionTypes.Find(id));

		}

		public IResolutionType Get(int id)
		{
			return _dataContext.ResolutionTypes.Find(id);
		}

		public IEnumerable<IResolutionType> GetAll()
		{
			return _dataContext.ResolutionTypes.ToList();
		}

		public async Task<IEnumerable<IResolutionType>> GetAllAsync()
		{
			return await _dataContext.ResolutionTypes.ToListAsync();
		}

		public async Task<IResolutionType> GetAsync(int id)
		{
			return await _dataContext.ResolutionTypes.FindAsync();
		}

		public void Update(IResolutionType item)
		{
			_dataContext.Entry(item).State = EntityState.Modified;
		}
	}
}
