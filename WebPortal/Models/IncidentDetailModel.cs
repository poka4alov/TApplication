using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ITILObjects;

namespace WebPortal.Models
{
	public class IncidentDetailModel
	{
		public string Identyficator { get; set; }
		
		public string Title { get; set; }

		public string Description { get; set; }

		public string OrderDate { get; set; }
	
		public string NotificationMethod { get; set; }
		public string NotificationMethodDesct { get; set; }

		public string Owner { get; set; }
		public string ServiceDescAgent { get; set; }
		public string CallbackMethod { get; set; }
		public string CallbackMethodDescr { get; set; } 
		
		public string IncidentPriority { get; set; }
		public string IncidentPriorityDescr { get; set; }

		public string IncidentPriorityStr { get { return IncidentPriority.ToString(); } private set { } }

		public IncidentDetailModel()
		{
		}
	}
}