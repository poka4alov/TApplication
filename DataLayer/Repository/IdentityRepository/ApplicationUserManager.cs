using System;
using System.Threading.Tasks;
using DataLayer.Model;
using Microsoft.AspNet.Identity;

namespace DataLayer
{
	public class ApplicationUserManager : UserManager<User>
	{
		public ApplicationUserManager(IUserStore<User> store)
				: base(store)
		{
		}

		//public  Task<User> FindByEmailAsync(string email)
		//{
		//	throw new NotImplementedException();
		//}
	}
}