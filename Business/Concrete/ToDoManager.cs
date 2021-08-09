using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation;

namespace Business.Concrete
{
   public class ToDoManager:IToDoService
   {
       private IToDoDal _toDoDal;

       public ToDoManager(IToDoDal toDoDal)
       {
           _toDoDal = toDoDal;
       }
       [CacheAspect]
        public IDataResult<List<Todo>> GetAll()
        {
         
           return new SuccessDataResult<List<Todo>>(_toDoDal.GetAll(),Messages.ToDoListed) ;
        }
        [CacheAspect]
        public IDataResult<List<ToDoDto>> GetAllByEmployeeId(int id)
        {
            return new SuccessDataResult<List<ToDoDto>>( _toDoDal.GetToDoDetails(t => t.EmployeeId == id),Messages.EmployeeToDoListed);
        }
        [CacheAspect]
        public IDataResult<List<ToDoDto>> GetAllByManagerId(int id)
        {
            return new SuccessDataResult<List<ToDoDto>>(_toDoDal.GetToDoDetails(t => t.ManagerId == id),Messages.ManagerToDoListed) ;
        }

        // Select * from ToDos where isEnded = false
        public IDataResult<List<ToDoDto>> GetAllIsEndedFalse()
        {
            return new SuccessDataResult<List<ToDoDto>>(_toDoDal.GetToDoDetails(t => t.IsEnded == false),Messages.UnfinishedTodosListed) ;
        }

        public IDataResult<List<ToDoDto>> GetAllIsEndedTrue()
        {
            return new SuccessDataResult<List<ToDoDto>>(_toDoDal.GetToDoDetails(t => t.IsEnded == true), Messages.FinishedTodosListed);
        }

        [CacheAspect]
        public IDataResult<List<ToDoDto>> GetAllIsAppointedTrue()
        {
            return new SuccessDataResult<List<ToDoDto>>( _toDoDal.GetToDoDetails(t => t.IsAppointed == true),Messages.AppointedTodosListed);
        }
        [CacheAspect]
        public IDataResult<List<Todo>> GetAllIsAppointedFalse()
        {
            return new SuccessDataResult<List<Todo>>(_toDoDal.GetAll(t => t.IsAppointed == false), Messages.UnAppointedTodosListed);
        }

        
        public IDataResult<List<ToDoDto>> GetAllToDoDetails()
        {
            return new SuccessDataResult<List<ToDoDto>>(_toDoDal.GetToDoDetails(),Messages.ToDoListed) ;
        }

        [ValidationAspect(typeof(TodoValidator))]
       // [SecuredOperation("director,admin")]
        [CacheRemoveAspect("IToDoService.Get")]
        public IResult Add(Todo toDo)
        {
          IResult result=  BusinessRules.Run(CheckIfToDoDescriptionExists(toDo.Description));

          if (result != null)
          {
              return new ErrorResult(result.Message);
          }
            _toDoDal.Add(toDo);
              return new SuccessResult(Messages.ToDoAdded);
           
        }
        [CacheRemoveAspect("IToDoService.Get")]
        public IResult Update(Todo todo)
        {
            _toDoDal.Update(todo);
            return new SuccessResult(Messages.ToDoUpdated);
        }
        [CacheAspect]
        public IDataResult<Todo> GetById(int toDoId)
        {
            return new SuccessDataResult<Todo>(_toDoDal.Get(t => t.ToDoId == toDoId),Messages.ToDoFound) ;
        }

        private IResult CheckIfToDoDescriptionExists(string description)
        {
           var result = this._toDoDal.GetAll(t => t.Description == description.ToString()).Any();
           if (result)
           {
               return new ErrorResult("Bu tanıma sahip bir todo zaten var.");
           }

           return new SuccessResult();
        }
    }
}
