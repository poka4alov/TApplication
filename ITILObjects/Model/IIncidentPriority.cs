using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ITILObjects.Model
{
	public interface IIncidentPriority
	{
		int Id { get; set; }
		 string Title { get; set; }
		 string Description { get; set; }
		 IUrgency IncidentUrgency { get;  set; }
		 IImpact IncidentImpact { get;  set; }
		 string ResolutionTime { get; set; }
		 string ResponceTime { get; set; }
		
	}
}