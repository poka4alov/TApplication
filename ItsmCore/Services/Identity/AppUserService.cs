using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using ITILObjects;
using DataLayer.Model;
using Microsoft.AspNet.Identity;
using System.Security.Claims;

namespace ItsmCore.Services.Identity
{
	public class AppUserService:IDisposable
	{
		IdentityUnitOfWork _unitOfWork;

		public AppUserService()
		{
			_unitOfWork = new IdentityUnitOfWork();
		}

		public async Task<OperationDetails> Create(AppUser appUser)
		{
			User _user = await _unitOfWork.ApplicationUserManager.FindByEmailAsync(appUser.Email);
			if (_user == null)
			{
				_user = new User { Email = appUser.Email, UserName = appUser.Email };
				var _reult = await _unitOfWork.ApplicationUserManager.CreateAsync(_user, appUser.Password);
				if (_reult.Errors.Count() > 0)
					return new OperationDetails(false, _reult.Errors.FirstOrDefault(), "");
				// добавляем роль
				await _unitOfWork.ApplicationUserManager.AddToRoleAsync(_user.Id, appUser.Role);
				// создаем профиль клиента
				UserProfile _userProfile = new UserProfile { Id = _user.Id, Address = appUser.Address, Name = appUser.Name };
				_unitOfWork.ApplicationUserProfileManager.Create(_userProfile);
				await _unitOfWork.SaveAsync();
				return new OperationDetails(true, "Регистрация успешно пройдена", "");
			}
			else
			{
				return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
			}
		}

		public async Task<ClaimsIdentity> Authenticate(AppUser appUser, string authenticateType)
		{
			ClaimsIdentity _claim = null;
			// 
			User _user = await _unitOfWork.ApplicationUserManager.FindAsync(appUser.Email, appUser.Password);
			//
			if (_user != null)
				_claim = await _unitOfWork.ApplicationUserManager.CreateIdentityAsync(_user,
											authenticateType);
			return _claim;
		}

		//public async Task<IAsyncResult> CreateProfile(AppUser appUser, UserProfile userProfile)
		//{
		//	_unitOfWork.ApplicationUserProfileManager.(userProfile)
		//}

		public void Dispose()
		{
			_unitOfWork.Dispose();
		}


	}


}
