using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Model;
using ITILObjects.Model;

namespace DataLayer.Repository
{
	public class CategoryRecordRepository : IRepository<ICategoryRecord>
	{

		ItsmDataContext _dataContext;
		public CategoryRecordRepository(ItsmDataContext dataContext)
		{
			_dataContext =  dataContext;
		}
		public void Create(ICategoryRecord item)
		{
			_dataContext.CategoryRecords.Add((CategoryRecord)item);
		}

		public void Delete(int id)
		{
			_dataContext.CategoryRecords.Remove(_dataContext.CategoryRecords.Find(id));
		}

		public ICategoryRecord Get(int id)
		{
			return _dataContext.CategoryRecords.Find(id);
		}

		public IEnumerable<ICategoryRecord> GetAll()
		{
			return _dataContext.CategoryRecords.ToList();
		}

		public async Task<IEnumerable<ICategoryRecord>> GetAllAsync()
		{
			return await _dataContext.CategoryRecords.ToListAsync();
		}

		public async Task<ICategoryRecord> GetAsync(int id)
		{
			return await _dataContext.CategoryRecords.FindAsync(id);
		}

		public void Update(ICategoryRecord item)
		{
			_dataContext.Entry(item).State = EntityState.Modified;
		}
	}
}
