using DataLayer.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ITILObjects.Model;

namespace DataLayer.Repository
{
	public class MethodOfNotificationRepository : IRepository<IMethodOfNotification>
	{
		private ItsmDataContext _dataContext;
		public MethodOfNotificationRepository(ItsmDataContext dataContext)
		{
			_dataContext = dataContext;
		}
		public void Create(IMethodOfNotification item)
		{
			_dataContext.MethodOfNotifications.Add((MethodOfNotification)item);
		}

		public void Delete(int id)
		{
			_dataContext.MethodOfNotifications.Remove(_dataContext.MethodOfNotifications.Find(id));
		}

		public IMethodOfNotification Get(int id)
		{
			return	_dataContext.MethodOfNotifications.Find(id);
		}

		public IEnumerable<IMethodOfNotification> GetAll()
		{
			return _dataContext.MethodOfNotifications.ToList();
		}

		public async Task<IEnumerable<IMethodOfNotification>> GetAllAsync()
		{
			return await _dataContext.MethodOfNotifications.ToListAsync() ;
		}

		public async Task<IMethodOfNotification> GetAsync(int id)
		{
			return await _dataContext.MethodOfNotifications.FindAsync(id);
		}

		public void Update(IMethodOfNotification item)
		{
			_dataContext.Entry(item).State = EntityState.Modified;
		}
	}
}
