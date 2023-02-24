using System;
using System.Linq.Expressions;

namespace BulkyBook.DataAccess.Repository.IRepository
{
	public interface IRepository<T> where T : class 
	{
		//

		T GetFirstOrDefault(Expression<Func<T, bool>> filter);

        T GetFirstOrDefault(Expression<Func<T, bool>> filter, string includeProps);

        IEnumerable<T> GetAll();

        IEnumerable<T> GetAll(string includeProps);

        void Add(T entity);

		void Remove(T entity);

		void RemoveRange(IEnumerable<T> entity);
		
	}
}

