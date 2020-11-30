using NTier.Core.Entity;
using NTier.Core.Enums;
using NTier.Core.Service;
using NTier.Maintenance.Model.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace NTier.Maintenance.Service.Base
{
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {
        readonly ProjectContext _db;

        protected BaseService()
        {
            _db = new ProjectContext();
        }
        public void Add(T item)
        {
            _db.Set<T>().Add(item);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Any(exp);
        }

        public List<T> GetActive()
        {
            return _db.Set<T>().Where(x => x.Status != Status.Deleted).ToList();
        }

        public List<T> GetAll()
        {
            return _db.Set<T>().ToList();
        }

        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().FirstOrDefault(exp);
        }

        public T GetById(Guid id)
        {
            return _db.Set<T>().Find(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return _db.Set<T>().Where(exp).ToList();
        }

        public bool Remove(Guid id)
        {
            try
            {
                GetById(id).Status = Status.Deleted;
                Save();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Remove(T item)
        {

            if (item !=null)
            {
                item.Status = Status.Deleted;
                Save();
                return true; 
            }
            return false;
        }

        public int Save()
        {
            return _db.SaveChanges();
        }

        public void Update(T item)
        {
            T oldData = GetById(item.Id);
            item.CreatedDate = oldData.CreatedDate;
            item.CreatedComputerName = oldData.CreatedComputerName;
            item.CreatedUserName = oldData.CreatedUserName;
            DbEntityEntry entityEntry = _db.Entry(oldData);
            entityEntry.CurrentValues.SetValues(item);
            Save();
        }
    }
}
