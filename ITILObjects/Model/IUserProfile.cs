using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITILObjects.Model
{
	public interface IUserProfile
	{
		string Id { get; set; }
		string Name { get; set; }
		string Position { get; set; }
		string Address { get; set; }
		string AvatarPathStr { get; set; }
		ICollection<IMethodOfNotification> MethodOfNotifications { get; set; }

	}
}
