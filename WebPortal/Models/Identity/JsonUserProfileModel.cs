using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITILObjects.Model;

namespace WebPortal.Models.Identity
{
	public class JsonUserProfileModel
	{
		public string Id { get ; set ; }
		public string Name { get ; set ; }
		public string Position { get ; set ; }
		public string Address { get ; set ; }
		public string AvatarPathStr { get ; set ; }
		public ICollection<IMethodOfNotification> MethodOfNotifications { get ; set ; }
	}
}