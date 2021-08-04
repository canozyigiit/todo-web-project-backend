using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entities.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    //Generic constraint
   public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAll(Expression<Func<T,bool>> filter = null);//Farklı isteklere göre filtre
        T Get(Expression<Func<T, bool>> filter);
    }
}
