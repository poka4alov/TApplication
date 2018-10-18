using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITILObjects.Model
{
	public interface IClosureData
	{
		IEnumerable<ICategoryRecord> ClosureCategories { get; set; }
		// IProblem ProblemRised {get;set;}
		IResolutionType ResolutionType  { get; set; }
		string CustomerFeedback { get; set; }
	}
}
