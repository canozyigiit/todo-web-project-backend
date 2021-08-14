using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
   public interface IToDoService
   {
       IDataResult<List<Todo>> GetAll();
       IDataResult<List<ToDoDto>> GetAllByEmployeeId(int id);
       IDataResult<List<ToDoDto>> GetAllByManagerId(int id);
       IDataResult<List<ToDoDto>> GetAllIsEndedFalse();
       IDataResult<List<ToDoDto>> GetAllIsEndedTrue();
        IDataResult<List<ToDoDto>> GetAllIsAppointedTrue();
       IDataResult<List<Todo>> GetAllIsAppointedFalse();
        IDataResult<List<ToDoDto>> GetAllToDoDetails();
       IResult Add(Todo toDo);
       IResult Delete(Todo toDo);
        IResult Update(Todo todo);
       IDataResult<Todo> GetById(int toDoId);


   }
}
