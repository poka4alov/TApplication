using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITILObjects.Model;


namespace DataLayer.Model
{
	public class CategoryRecord : ICategoryRecord
	{
		public int Id { get ; set ; }
		public string Title { get ; set ; }
		public string Description { get ; set ; }
		public ICategoryRecord PearentCategory { get=> PearentCategoryRec; set=> PearentCategoryRec=(CategoryRecord)value; }

		public virtual CategoryRecord PearentCategoryRec { get; set; }

		public virtual ICollection<CategoryRecord> PearentCategoryRecords { get; set; }

	}
}
