﻿using DataBase.DataBases;
using DataBase.Models;
using DataBase.Ninject;
using Ninject;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DataBase
{
    public class OperationDb : IOperationDb
    {
        private readonly ApplicationContext _db;

        public OperationDb()
        {
            _db = NinjectContext.Kernel.Get<ApplicationContext>();
        }

        public void CreateModel<T>(T model) where T : class, IEntity
        {
            _db.Set<T>().Add(model);
            _db.SaveChanges();
        }

        public IQueryable<T> GetModels<T>() where T : class, IEntity
        {
            return _db.Set<T>();
        }

        public void RemoveModel<T>(T model) where T : class, IEntity
        {
            _db.Set<T>().Remove(model);
            _db.SaveChanges();
        }

        public void UpdateModel<T>(T model) where T : class, IEntity
        {
            var m = _db.Set<T>().Find(model.Id);
            m = model;
            _db.SaveChanges();
        }

        public T GetModelFirstOfDefault<T>(Expression<Func<T, bool>> predicate) where T : class, IEntity
        {
            return _db.Set<T>().Where(predicate).FirstOrDefault();
        }

        public IQueryable<T> GetModels<T>(Expression<Func<T, bool>> predicate) where T : class, IEntity
        {
            return _db.Set<T>().Where(predicate);
        }
    }
}
