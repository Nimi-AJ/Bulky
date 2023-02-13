using System;
using System.Collections.Generic;
using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
        private ApplicationDbContext _db;
		public ProductRepository(ApplicationDbContext db) : base(db)
		{
            _db = db;
		}

        public void Update(Product obj)
        {

            //_db.Products.Update(obj); //Alternative way of updating entity

            var objFromDb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);

            if(objFromDb != null)
            {
                objFromDb.Title = obj.Title;
                objFromDb.Title = obj.Title;
                objFromDb.Title = obj.Title;
                objFromDb.Title = obj.Title;
            }
        }
    }
}

