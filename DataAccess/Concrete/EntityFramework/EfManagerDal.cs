using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfManagerDal:IManagerDal
    {
        public void Add(Manager entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Manager entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Manager entity)
        {
            throw new NotImplementedException();
        }

        public List<Manager> GetAll(Expression<Func<Manager, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Manager Get(Expression<Func<Manager, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
