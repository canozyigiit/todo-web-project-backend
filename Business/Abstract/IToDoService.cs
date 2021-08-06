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
       IDataResult<List<Todo>> GetAllByEmployeeId(int id);
       IDataResult<List<Todo>> GetAllByManagerId(int id);
       IDataResult<List<Todo>> GetAllIsEndedFalse();
       IDataResult<List<Todo>> GetAllIsAppointedTrue();
       IDataResult<List<Todo>> GetAllIsAppointedFalse();
        IDataResult<List<ToDoDto>> GetAllToDoDetails();
       IResult Add(Todo toDo);
       IResult Update(Todo todo);
       IDataResult<Todo> GetById(int toDoId);


   }
}
