using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework
{
  public  class EfEmployeeDal : EfEntityRepositoryBase<Employee, TodoContext>,IEmployeeDal
    {
        public List<EmployeeDto> GetallEmployeeDtos()
        {
            using (TodoContext context = new TodoContext())
            {
                var result = from e in context.Employees
                    join u in context.Users on e.UserId equals u.Id
                    //join u in context.Users on e.EmployeeId equals u.Id 


                    select new EmployeeDto()
                    {
                       EmployeeId = e.EmployeeId,
                       FirstName = u.FirstName,
                       LastName = u.LastName,
                       Email = u.Email,
                       Position = e.Position
                       

                    };
                return result.ToList();



            }
        }
    }
}
