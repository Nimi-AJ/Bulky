using System;
using System.Collections.Generic;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository
{
	public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
	{
        private ApplicationDbContext _db;
		public CoverTypeRepository(ApplicationDbContext db) : base(db)
		{
            _db = db;
		}

        public void Update(CoverType obj)
        {
            //IEnumerable<CoverType> = _db.CoverType;
            _db.CoverTypes.Update(obj);
        }
    }
}

