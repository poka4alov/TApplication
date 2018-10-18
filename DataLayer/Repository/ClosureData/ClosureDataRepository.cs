using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITILObjects.Model;
using DataLayer;
using DataLayer.Model;
using System.Data.Entity;

namespace DataLayer.Repository.ClosureData
{
	public class ClosureDataRepository : IRepository<IClosureData>
	{
		ItsmDataContext _dataContext;
		public ClosureDataRepository(ItsmDataContext dataContext)
		{
			_dataContext = dataContext;
		}
		public void Create(IClosureData item)
		{
			_dataContext.ClosureDatas.Add((DataLayer.Model.ClosureData)item);
		}

		public void Delete(int id)
		{
			_dataContext.ClosureDatas.Remove(_dataContext.ClosureDatas.Find(id));
		}

		public IClosureData Get(int id)
		{
			return _dataContext.ClosureDatas.Find(id);
		}

		public IEnumerable<IClosureData> GetAll()
		{
			return _dataContext.ClosureDatas.ToList();
		}

		public async Task<IEnumerable<IClosureData>> GetAllAsync()
		{
			return await _dataContext.ClosureDatas.ToListAsync();
		}

		public async Task<IClosureData> GetAsync(int id)
		{
			return await _dataContext.ClosureDatas.FindAsync(id);
		}

		public void Update(IClosureData item)
		{
			_dataContext.Entry(item).State = EntityState.Modified;
		}
	}
}
