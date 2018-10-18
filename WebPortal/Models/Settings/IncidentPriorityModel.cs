using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITILObjects.Model;

namespace WebPortal.Models.Settings
{
	public class IncidentPriorityModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public int UrgencyId { get; set; }
		public int ImpactId { get; set; }
		public string ResolutionTime { get; set; }
		public string ResponceTime { get; set; }

		public IEnumerable<IUrgency>  UrgenciesList { get; set; }
		public IEnumerable<IImpact> ImpactsList { get; set; }
	}
}