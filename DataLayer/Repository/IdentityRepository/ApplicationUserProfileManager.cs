using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Model;
using ITILObjects.Model;

namespace DataLayer.Repository
{
	// Это реализация самого обычного репозитория 
	// тут поправить все на репозиторийии нужно и идентити тоже загнать под репозитории чобы не парить потом
	public class ApplicationUserProfileManager:IRepository<IUserProfile>
	{
		IdentityDataContext _dataContext;
		public ApplicationUserProfileManager(IdentityDataContext dataContext)
		{
			_dataContext = dataContext;
		}

		public void Create(IUserProfile item)
		{
			UserProfile _item = new UserProfile()
			{
				Id = item.Id,
				AvatarPathStr = item.AvatarPathStr,
				Name = item.Name,
				Position = item.Position,
				MethodOfNotifications =  item.MethodOfNotifications,
				Address = item.Address,
				 
			};
			_dataContext.ClientProfiles.Add(_item);
			_dataContext.SaveChanges();
		}
		
		public void Delete()
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			_dataContext.ClientProfiles.Remove(_dataContext.ClientProfiles.Find(id));
		}

		public void Dispose()
		{
			_dataContext.Dispose();
		}

		public IUserProfile Get(string id)
		{
			return _dataContext.ClientProfiles.Find(id);
		}

		public IUserProfile Get(int id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<IUserProfile> GetAll()
		{
			return _dataContext.ClientProfiles.ToList();
		}

		public async Task<IEnumerable<IUserProfile>> GetAllAsync()
		{
			return await _dataContext.ClientProfiles.ToListAsync();
		}

		public async Task<IUserProfile> GetAsync(string id)
		{
			return await _dataContext.ClientProfiles.FindAsync(id);
		}

		public Task<IUserProfile> GetAsync(int id)
		{
			throw new NotImplementedException();
		}

		public void Update(IUserProfile item)
		{
			_dataContext.Entry(item).State = EntityState.Modified;
		}
	}
}
