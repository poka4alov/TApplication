using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ITILObjects.Model;

namespace DataLayer.Model
{
	public class UserProfile:IUserProfile
	{
		[Key]
		[ForeignKey("ApplicationUser")]
		public string Id { get; set; }

		public string Name { get; set; }
		public string Position { get; set; }
		public string Address { get; set; }
		public string AvatarPathStr { get; set; }
		public ICollection<IMethodOfNotification> MethodOfNotifications {
			get => (ICollection<IMethodOfNotification>)NotificationMethods;
			set => NotificationMethods = (ICollection<MethodOfNotification>)value;
		}

		public virtual User ApplicationUser { get; set; }
		public virtual ICollection<MethodOfNotification> NotificationMethods { get; set; }
	}
}
