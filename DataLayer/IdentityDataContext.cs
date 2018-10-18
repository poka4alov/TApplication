using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using DataLayer.Model;
using ITILObjects;
using Microsoft.AspNet.Identity;
using System.Linq;
using DataLayer.Repository;

namespace DataLayer
{

	class IdentityDataContextInitializer : DropCreateDatabaseAlways<IdentityDataContext>
	{
		protected override void Seed(IdentityDataContext db)
		{
			ApplicationUserManager _userManager = new ApplicationUserManager(new UserStore<User>(db));
			ApplicationRoleManager _roleManager = new ApplicationRoleManager(new RoleStore<Role>(db));
			_roleManager.Create(new Role() { Name="admin"});
			_roleManager.Create(new Role() { Name="user"});
			User _user = new User()
			{
				Email = "somemail@mail.ru",
				UserName = "somemail@mail.ru",
			};
			var _result = _userManager.Create(_user, "ad46D_ewr3");
			if (_result.Errors.Count() > 0) {
				 new OperationDetails(false, _result.Errors.FirstOrDefault(), "");
			}
			_userManager.AddToRole(_user.Id, "admin");
			UserProfile _userProfile = new UserProfile
			{
				Id = _user.Id,
				Address = "Doneck Razdolnaya 29A",
				Name = "Sergey Sergeev",
				Position ="Administrator",
				AvatarPathStr = "Content/img/user.jpg",
			};
			ApplicationUserProfileManager _applicationUserProfileManager = new ApplicationUserProfileManager(db);
			_applicationUserProfileManager.Create(_userProfile);
			db.SaveChanges();
	
		}
	}
	
	public class IdentityDataContext : IdentityDbContext<User>
	{
		static IdentityDataContext()
		{
			Database.SetInitializer<IdentityDataContext>(new IdentityDataContextInitializer());
		}

	public IdentityDataContext() : base("name=ItsmDataContext") { }

		
		public DbSet<UserProfile> ClientProfiles { get; set; }
	}
}
