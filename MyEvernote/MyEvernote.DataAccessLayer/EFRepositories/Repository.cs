﻿using MyEvernote.DataAccessLayer.Abstract;
using MyEvernote.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace MyEvernote.DataAccessLayer.EFRepositories
{
    public class Repository<T> : RepositoryBase, IRepository<T> where T : class
    {
        private readonly DbSet<T> _objectSet;

        public Repository()
        {
            _objectSet = db.Set<T>();
        }

        public List<Note> Tolist()
        {
            throw new NotImplementedException();
        }

        public List<T> List()
        {
            return _objectSet.ToList();
        }

        public IQueryable<T> List(Expression<Func<T, bool>> where)
        {
            return _objectSet.Where(where);
        }

        public int Insert(T obj)
        {
            _objectSet.Add(obj);
            return Save();
        }

        public int Update()
        {
            return Save();
        }

        public int Delete(T obj)
        {
            _objectSet.Remove(obj);
            return Save();
        }

        public int Save()
        {
            return db.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _objectSet.FirstOrDefault(where);
        }
    }
}
