using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Web_UnitOfWork_EF.Repository.Interface
{
    public interface IUnitOfWork<T> where T: class 
    {
        int Add(T model);
        int Update(T model);
        void Delete(T model);
        IEnumerable<T> GetAll();
        T GetById(object id);
        IEnumerable<T> Where(Expression<Func<T, bool>> expression);
        IEnumerable<T> OrderBy(Expression<System.Func<T, bool>> expression);

    }
}
