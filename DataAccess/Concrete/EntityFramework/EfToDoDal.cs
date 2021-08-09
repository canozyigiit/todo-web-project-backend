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
        public List<ToDoDto> GetToDoDetails(Expression<Func<Todo, bool>> filter = null)
        {
            using (TodoContext context = new TodoContext())
            {
                var result = from t in filter == null ? context.ToDos : context.ToDos.Where(filter)
                    join e in context.Employees on t.EmployeeId equals e.EmployeeId
                    join m in context.Managers on t.ManagerId equals m.ManagerId
                    join u in context.Users on e.UserId equals u.Id 
                    join user in context.Users on m.UserId equals user.Id
                   

                    select new ToDoDto()
                    {
                        ToDoId = t.ToDoId,
                        ManagerId = t.ManagerId,
                        EmployeeId = t.EmployeeId,
                        EmployeeFirstName = u.FirstName,
                        EmployeeLastName = u.LastName,
                        Description = t.Description,
                        ManagerFirstName = user.FirstName,
                        ManagerLastName = user.LastName,
                        AppointedDate = t.AppointedDate,
                        CreatedDate = t.CreatedDate,
                        IsAppointed = t.IsAppointed,
                        IsEnded = t.IsEnded

                    };
                return result.ToList();



            }
        }
    }
}
