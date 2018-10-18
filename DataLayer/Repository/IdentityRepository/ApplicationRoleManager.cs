using DataLayer.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataLayer
{
	public class ApplicationRoleManager : RoleManager<Role>
	{
		public ApplicationRoleManager(RoleStore<Role> store)
					: base(store)
		{ }
	}
}
