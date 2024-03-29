﻿using System;
using System.Linq.Expressions;
using BulkyBook.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BulkyBook.DataAccess.Repository
{
	public class Repository<T> : IRepository<T> where T : class
	{

        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

		public Repository(ApplicationDbContext db)
		{
            _db = db;
            this.dbSet = _db.Set<T>();
		}

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = dbSet;

            return query.ToList();
        }

        public IEnumerable<T> GetAll(string includeProps)
        {
            IQueryable<T> query = dbSet;
            foreach (var includeProp in includeProps.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp);
            }

            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);


            return query.FirstOrDefault();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string includeProps)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);
            foreach (var includeProp in includeProps.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProp);
            }
            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}

