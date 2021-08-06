using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
  public  class ManagerMng:IManagerService


  {
      private IManagerDal _managerDal;
      private IToDoService _toDoService;
      private IEmployeeService _employeeService;

      public ManagerMng(IManagerDal managerDal,IToDoService toDoService,IEmployeeService employeeService)
      {
          this._toDoService = toDoService;
          this._managerDal = managerDal;
          this._employeeService = employeeService;
      }
        [CacheAspect]
        public IDataResult<List<Manager>> GetAll()
        {
            return new SuccessDataResult<List<Manager>>(this._managerDal.GetAll(), Messages.ManagerListed);
        }

        public IResult Add(Manager manager)
        {
            _managerDal.Add(manager);
            return new SuccessResult(Messages.ManagerAdded);
        }
        [CacheAspect]
        public IDataResult<Manager> GetById(int managerId)
        {
            return new SuccessDataResult<Manager>(_managerDal.Get(m => m.ManagerId == managerId), Messages.ManagerFound);

        }
        [SecuredOperation("director,admin")]
        public IResult ToDoAppointe(int todoId, int employeeId)
        {
            IResult result = BusinessRules.Run(CheckIfToDoCountEmployeeCorrect(employeeId), CheckIfIsEmployee(employeeId));
            if (result != null)
            {
                return result;
            }
            
            var toDo =_toDoService.GetById(todoId).Data;

                toDo.EmployeeId = employeeId;
                toDo.AppointedDate = DateTime.Now;
                toDo.IsAppointed = true;
                this._toDoService.Update(toDo);
                //TODO: Employee bilgilendirici e posta gidecek
                return new SuccessResult(Messages.ToDoAppointed);
        }

        private IResult CheckIfToDoCountEmployeeCorrect(int employeeId)
        {
            var result = this._toDoService.GetAllByEmployeeId(employeeId).Data.Count;
            if (result > 2)
            {
                return new ErrorResult("Bu çalışana ait zaten 2'den fazla todo var");

            }

            return new SuccessResult();
        }

        private IResult CheckIfIsEmployee(int employeeId)
        {
            var employee = _employeeService.GetById(employeeId).Data;
            if (employee == null)
            {
                return new ErrorResult(Messages.EmployeeNotFound);
            }

            return new SuccessResult();
        }

      
  }
}
