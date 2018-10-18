using DataLayer;
using System;
using ITILObjects.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItsmCore.Services.Identity
{
	public class UserProfileService:IDisposable
	{
		IdentityUnitOfWork _unitOfWork;
		public UserProfileService()
		{
			_unitOfWork = new IdentityUnitOfWork();
		}

		public IUserProfile GetUserProfile(string id)
		{
			return _unitOfWork.ApplicationUserProfileManager.Get(id);
		}

		public async Task<IUserProfile> GetUserProfileAsync(string id)
		{
			return await _unitOfWork.ApplicationUserProfileManager.GetAsync(id);
		}

		public void SetUserProfile(IUserProfile userProfile, string userId)
		{

		}

		public void Dispose()
		{
			_unitOfWork.Dispose();
		}
	}
}
