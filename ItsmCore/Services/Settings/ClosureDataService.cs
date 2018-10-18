using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using ITILObjects.Model;

namespace ItsmCore.Services.Settings
{
	public class ClosureDataService
	{
		UnitOfWork _unitOfWork;
		public ClosureDataService()
		{
			_unitOfWork = new UnitOfWork();
		}

		#region //Resolution Type
		public IResolutionType GetResolutionById(int id)
		{
			return _unitOfWork.ResolutionType.Get(id);
		}
		public async Task<IResolutionType>  GetResolutionByIdAsync(int id)
		{
			return await _unitOfWork.ResolutionType.GetAsync(id);
		}
		public IEnumerable<IResolutionType> GetResolutionTypes()
		{
			return _unitOfWork.ResolutionType.GetAll();
		}
		public async Task<IEnumerable<IResolutionType>> GetResolutionTypesAsync()
		{
			return await _unitOfWork.ResolutionType.GetAllAsync();
		}
		public void CreateResolutionType(IResolutionType item)
		{
			_unitOfWork.ResolutionType.Create(item);
			_unitOfWork.Save();
		}
		public void UpdateResolutionType(IResolutionType item)
		{
			_unitOfWork.ResolutionType.Update(item);
			_unitOfWork.Save();
		}
		public void DeleteResolutionType(int id)
		{
			_unitOfWork.ResolutionType.Delete(id);
			_unitOfWork.Save();
		}
		#endregion

		#region //Closure Data
		public IClosureData GetClosureDataById(int id)
		{
			return _unitOfWork.ClosureData.Get(id);
		}
		public async Task<IClosureData> GetClosureDataByIdAsync(int id)
		{
			return await _unitOfWork.ClosureData.GetAsync(id);
		}
		public IEnumerable<IClosureData> GetClosureDatas()
		{
			return _unitOfWork.ClosureData.GetAll();
		}
		public async Task<IEnumerable<IClosureData>> GetClosureDatasAsync()
		{
			return await _unitOfWork.ClosureData.GetAllAsync();
		}
		public void CreateClosureData(IClosureData item)
		{
			_unitOfWork.ClosureData.Create(item);
			_unitOfWork.Save();
		}
		public void UpdateClosureData(IClosureData item)
		{
			_unitOfWork.ClosureData.Update(item);
			_unitOfWork.Save();
		}
		public void DeleteClosureData(int id)
		{
			_unitOfWork.ClosureData.Delete(id);
			_unitOfWork.Save();
		}

		public void AddClosureCategoyById(IClosureData item, int closureCategoryId)
		{
			item.ClosureCategories.ToList().Add(_unitOfWork.CategoryRecord.Get(closureCategoryId));
			UpdateClosureData(item);
		}

		
		
		#endregion
		

	}
}
