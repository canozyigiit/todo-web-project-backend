using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfToDoDal:EfEntityRepositoryBase<Todo,TodoContext>,IToDoDal
    {
        public List<ToDoDto> GetToDoDetails()
        {
            using (TodoContext context = new TodoContext())
            {
                var result = from t in context.ToDos
                    join e in context.Employees
                        on t.EmployeeId equals e.EmployeeId
                    join u in context.Users
                        on e.EmployeeId equals u.Id
                  
                    select new ToDoDto()
                    {
                        ToDoId = t.ToDoId,
                        EmployeeName = u.FirstName,
                        Description = t.Description,

                    };
                return result.ToList();



            }
        }
    }
}
