using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
   public interface IToDoService
   {
       List<Todo> GetAll();
       List<Todo> GetAllByEmployeeId(int id);
       List<Todo> GetAllByManagerId(int id);
       List<Todo> GetAllIsEndedFalse();
       List<Todo> GetAllIsAppointed(bool isAppointed);
       List<ToDoDto> GetAllToDoDetails();

   }
}
