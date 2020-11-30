using NTier.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NTier.Core.Service
{
    public interface ICoreService<T> where T: CoreEntity
    {
        void Add(T item);
        void Update(T item);
        Boolean Remove(Guid id);
        Boolean Remove(T item);
        List<T> GetAll();
        List<T> GetActive();
        List<T> GetDefault(Expression<Func<T, Boolean>> exp);
        T GetById(Guid id);
        T GetByDefault(Expression<Func<T, Boolean>> exp);
        Boolean Any(Expression<Func<T, Boolean>> exp);
        Int32 Save();
    }
}
