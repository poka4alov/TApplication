using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Repository;
using DataLayer.Model;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataLayer
{
	public class IdentityUnitOfWork
	{
		private IdentityDataContext _dataContext;

		private ApplicationUserManager _userManager;
		private ApplicationRoleManager _roleManager;
		private ApplicationUserProfileManager _userProfileManager;

		public ApplicationUserManager ApplicationUserManager { get => _userManager; }
		public ApplicationRoleManager ApplicationRoleManager { get => _roleManager; }
		public ApplicationUserProfileManager ApplicationUserProfileManager { get => _userProfileManager; }

		public IdentityUnitOfWork()
		{
			_dataContext = new IdentityDataContext();
			_userManager = new ApplicationUserManager(new UserStore<User>(_dataContext));
			_roleManager = new ApplicationRoleManager(new RoleStore<Role>(_dataContext));
			_userProfileManager = new ApplicationUserProfileManager(_dataContext);
		}

		public void Save()
		{
			_dataContext.SaveChanges();
		}

		public async Task SaveAsync()
		{
			await _dataContext.SaveChangesAsync();
		}

		private bool disposed = false;

		public virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					_dataContext.Dispose();
				}
				this.disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
