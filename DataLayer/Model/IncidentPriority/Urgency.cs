using ITILObjects.Model;
using System.Collections.Generic;

namespace DataLayer.Model
{
	public class Urgency : IUrgency
	{

		public Urgency()
		{
			IncidentPriorities = new HashSet<IncidentPriority>();
		}
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		
		public virtual ICollection<IncidentPriority> IncidentPriorities { get; set; }
	}
}

