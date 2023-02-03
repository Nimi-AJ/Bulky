
using System;
using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository.IRepository
{
	public interface ICoverTypeRepository : IRepository<Category>
	{

		void Update(CoverType obj);

		
	}
}

