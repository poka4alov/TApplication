using ITILObjects.Model;
using System.Collections.Generic;

namespace DataLayer.Model
{
	public class IncidentPriority : IIncidentPriority
	{
		public IncidentPriority()
		{
			Incidents = new HashSet<Incident>();
		}
		public int Id { get; set; }
		public string Title { get ; set ; }
		public string Description { get ; set; }
		public IUrgency IncidentUrgency { get => Urgency; set => Urgency = (Urgency)value; }
		public IImpact IncidentImpact { get => Impact; set => Impact = (Impact)value; }
		public string ResolutionTime { get  ; set  ; }
		public string ResponceTime { get  ; set  ; }

		
		public virtual Urgency Urgency { get; set; }
		public virtual Impact Impact { get; set; }
		public virtual ICollection<Incident> Incidents { get; set; }
	}
}
