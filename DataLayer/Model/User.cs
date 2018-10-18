
using Microsoft.AspNet.Identity.EntityFramework;
namespace DataLayer.Model
{
	public class User: IdentityUser
	{
		public virtual UserProfile ClientProfile { get; set; }
	}
}
