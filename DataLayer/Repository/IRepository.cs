using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer;
namespace DataLayer.Repository
{
	public interface IRepository<T> where T : class
	{
		IEnumerable<T> GetAll();
		Task<IEnumerable<T>> GetAllAsync();
		T Get(int id);
		Task<T> GetAsync(int id);
		void Create(T item);
		void Update(T item);
		void Delete(int id);
	}
}
