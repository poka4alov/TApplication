using ITILObjects.Model;
using System;
using System.Collections.Generic;

namespace DataLayer.Model
{
	public class Incident : IIncident
	{
		public Incident()
		{
			MethodOfCallback = new HashSet<MethodOfNotification>();

		}
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime OrderDate { get; set; }
		public string Owner { get; set; }
		public string ServiceDescAgent { get; set; }

		public IMethodOfNotification NotificationMethod { get=>MethodOfNotification; set=>MethodOfNotification=(MethodOfNotification)value; }
		public ICollection<IMethodOfNotification> CallbackMethod { get => (ICollection<IMethodOfNotification>)MethodOfCallback ; set => MethodOfCallback = (ICollection<MethodOfNotification>)value; }
		public IIncidentPriority IncidentPriority { get=>Priority; set=>Priority=(IncidentPriority)value; }
		public IClosureData ClosureData { get =>Closure; set =>Closure=(ClosureData)value; }

		public virtual ICollection<MethodOfNotification> MethodOfCallback { get; set; }
		public virtual MethodOfNotification MethodOfNotification { get; set; }
		public virtual IncidentPriority Priority { get; set; }
		public virtual ClosureData Closure { get; set; }
		
	}
}
