using ITILObjects.Model;
using System.Collections.Generic;

namespace DataLayer.Model
{
	public class MethodOfNotification : IMethodOfNotification
	{
		public MethodOfNotification()
		{
			Incidents = new HashSet<Incident>();
		}
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Argument { get; set; }

		public virtual ICollection<Incident> Incidents { get; set; }
	}
}
