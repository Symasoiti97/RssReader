using DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public interface IOperationDb
    {
        void CreateModel<T>(T model) where T : class, IEntity;
        void RemoveModel<T>(T model) where T : class, IEntity;
        void UpdateModel<T>(T model) where T : class, IEntity;
        IQueryable<T> GetModels<T>() where T : class, IEntity;
        IQueryable<T> GetModels<T>(Expression<Func<T, bool>> predicate) where T : class, IEntity;
        T GetModelFirstOfDefault<T>(Expression<Func<T, bool>> predicate) where T : class, IEntity;
    }
}
