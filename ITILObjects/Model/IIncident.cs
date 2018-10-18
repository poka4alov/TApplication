using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITILObjects.Model;

namespace ITILObjects.Model
{
	public interface IIncident
	{
		 int Id { get; set; }
		 string Title { get; set; }
		 string Description { get; set; }
		 DateTime OrderDate { get; set; }
		 IMethodOfNotification NotificationMethod { get; set; }
		 string Owner { get; set; }
		 string ServiceDescAgent { get; set; }
		 ICollection<IMethodOfNotification> CallbackMethod { get; set; }
		 IIncidentPriority IncidentPriority { get; set; }
		 IClosureData ClosureData { get; set; }

	}
}
