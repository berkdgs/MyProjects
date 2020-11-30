using NTier.Core.Entity;
using NTier.Core.Enums;
using NTier.Core.Service;
using NTier.Model.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Service.Base
{
    public class BaseService<T> : Core.Service.ICoreService<T> where T : CoreEntity
    {
        ProjectContext db;
        public BaseService()
        {
            db = new ProjectContext();
        }

        public void Add(T item)
        {
            db.Set<T>().Add(item);
            Save();
        }

        public bool Any(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Any(exp);
        }

        public List<T> GetActive()
        {
            return db.Set<T>().Where(x => x.Status != Status.Deleted).ToList();
        }

        public List<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public T GetByDefault(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().FirstOrDefault(exp);
        }

        public T GetById(Guid id)
        {
            return db.Set<T>().Find(id);
        }

        public List<T> GetDefault(Expression<Func<T, bool>> exp)
        {
            return db.Set<T>().Where(exp).ToList();
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
            if (item != null)
            {
                item.Status = Status.Deleted;
                Save();
                return true;
            }
            return false;
        }

        public int Save()
        {
            return db.SaveChanges();
        }

        public void Update(T item)
        {
            T oldData = db.Set<T>().Find(item.Id);
            item.CreatedDate = oldData.CreatedDate;
            item.CreatedComputerName = oldData.CreatedComputerName;
            item.CreatedUserName = oldData.CreatedUserName;
            DbEntityEntry obj = db.Entry(oldData);
            obj.CurrentValues.SetValues(item);
            Save();
        }
    }
}
