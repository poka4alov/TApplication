using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITILObjects.Model;

namespace DataLayer.Model
{
	public class ClosureData : IClosureData
	{
		public int Id { get; set; }
		public IEnumerable<ICategoryRecord> ClosureCategories { get=>CategoryRecords; set=>CategoryRecords=(ICollection<CategoryRecord>)value; }
		public IResolutionType ResolutionType { get=>Resolution; set=>Resolution=(ResolutionType)value; }
		public string CustomerFeedback { get; set; }

		public ResolutionType Resolution{get;set;}
		public ICollection<CategoryRecord> CategoryRecords { get; set; }
	}
}
