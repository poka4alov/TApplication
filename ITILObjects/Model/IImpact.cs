using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITILObjects.Model
{
	public interface IImpact
	{
		int Id { get; set; }
		string Title { get; set; }
		string Description { get; set; }
	}
}
