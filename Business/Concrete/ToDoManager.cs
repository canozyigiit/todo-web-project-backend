using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Concrete
{
   public class ToDoManager:IToDoService
   {
       private IToDoDal _toDoDal;

       public ToDoManager(IToDoDal toDoDal)
       {
           _toDoDal = toDoDal;
       }
        public IDataResult<List<Todo>> GetAll()
        {
            //if (DateTime.Now.Hour ==22)
            //{
            //    return new ErrorDataResult<List<Todo>>("Sistem Bakımda");
            //}
           return new SuccessDataResult<List<Todo>>(_toDoDal.GetAll(),Messages.ToDoListed) ;
        }

        public IDataResult<List<Todo>> GetAllByEmployeeId(int id)
        {
            return new SuccessDataResult<List<Todo>>( _toDoDal.GetAll(t => t.EmployeeId == id),Messages.EmployeeToDoListed);
        }

        public IDataResult<List<Todo>> GetAllByManagerId(int id)
        {
            return new SuccessDataResult<List<Todo>>(_toDoDal.GetAll(t => t.ManagerId == id),Messages.ManagerToDoListed) ;
        }

        // Select * from ToDos where isEnded = false
        public IDataResult<List<Todo>> GetAllIsEndedFalse()
        {
            return new SuccessDataResult<List<Todo>>(_toDoDal.GetAll(t => t.IsEnded == false),Messages.UnfinishedTodosListed) ;
        }

        public IDataResult<List<Todo>> GetAllIsAppointed()
        {
            return new SuccessDataResult<List<Todo>>( _toDoDal.GetAll(t => t.IsAppointed == true),Messages.AppointedTodosListed);
        }

        public IDataResult<List<ToDoDto>> GetAllToDoDetails()
        {
            return new SuccessDataResult<List<ToDoDto>>(_toDoDal.GetToDoDetails(),Messages.ToDoListed) ;
        }

        public IResult Add(Todo toDo)
        {
            _toDoDal.Add(toDo);
            return new SuccessResult(Messages.ToDoAdded);
        }

        public IDataResult<Todo> GetById(int toDoId)
        {
            return new SuccessDataResult<Todo>(_toDoDal.Get(t => t.ToDoId == toDoId),Messages.ToDoFound) ;
        }
   }
}
