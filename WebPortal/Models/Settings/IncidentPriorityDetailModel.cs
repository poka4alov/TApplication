using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebPortal.Models.Settings
{
	public class IncidentPriorityDetailModel
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string UrgencyTitle { get; set; }
		public string ImpactTitle { get; set; }
		public string ResolutionTime { get; set; }
		public string ResponceTime { get; set; }
	}
}