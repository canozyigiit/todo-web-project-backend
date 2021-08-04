using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
  public  class EfEmployeeDal:IEmployeeDal
    {
        public void Add(Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Employee entity)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll(Expression<Func<Employee, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Employee Get(Expression<Func<Employee, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
