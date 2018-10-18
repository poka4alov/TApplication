using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITILObjects.Model;

namespace DataLayer.Model
{
	public class ResolutionType : IResolutionType
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }

		public ICollection<ClosureData> CloserDatas { get; set; }
	}
}
