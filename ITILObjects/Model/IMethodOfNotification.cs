
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ITILObjects.Model
{
	public interface IMethodOfNotification
	{
		int Id { get; set; }
		string Title { get; set; }
		string Description { get; set; }
		string Argument { get; set; }
		
	}
}