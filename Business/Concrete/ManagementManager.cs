using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Entities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Concrete
{
   public class ManagementManager:IManagementService
    {
        private IToDoService _toDoService;
        private IEmployeeService _employeeService;
        private IUserService _userService;
        private IManagerService _managerService;
        private IUserOperationClaimService _userOperationClaimService;
        private IEmailService _emailService;

        public ManagementManager(IToDoService toDoService,
            IEmployeeService employeeService,
            IUserService userService,
            IManagerService managerService,
            IUserOperationClaimService userOperationClaimService,
            IEmailService emailService)
        {
            _toDoService = toDoService;
            _employeeService = employeeService;
            _userService = userService;
            _managerService = managerService;
            _userOperationClaimService = userOperationClaimService;
            _emailService = emailService;
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IEmployeeService.Get")]
        public IResult MakeUserEmployee(string mail,string position)
        {
            var user = _userService.GetByMail(mail).Data;
            Employee employee = new Employee
            {
                UserId = user.Id,
                Position = position
            };
            _employeeService.Add(employee);
            user.IsAssigned = true;
            _userService.Update(user);
            return new SuccessResult(Messages.UserMadeEmployee);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IManagerService.Get")]
        public IResult MakeUserManager(string mail)
        {
            var user = _userService.GetByMail(mail).Data;
            Manager manager = new Manager
            {
                UserId = user.Id
            };
            user.IsAssigned = true;
            _userService.Update(user);
            _managerService.Add(manager);
            return new SuccessResult(Messages.UserMadeManager);
        }

        [SecuredOperation("admin")]
        public IResult MakeUserDirector(string mail)
        {
            User user = _userService.GetByMail(mail).Data;
            _userOperationClaimService.AddUserClaim(user);
            Message message = new Message(new string[] { user.Email.ToString() }, "Yeni Bir Rol Atandı", "Yeni bir rol atandı, sistemden kontrol edebilirsiniz.", null);
            _emailService.SendEmail(message);
            return new SuccessResult(Messages.UserMadeDirector);
        }


        [SecuredOperation("director,admin")]
        [CacheRemoveAspect("IToDoService.Get")]
        public IResult ToDoAppointe(int todoId, int employeeId)
        {
            IResult result = BusinessRules.Run(CheckIfToDoCountEmployeeCorrect(employeeId), CheckIfIsEmployee(employeeId));
            if (result != null)
            {
                return result;
            }

            var toDo = _toDoService.GetById(todoId).Data;
            Employee employee = _employeeService.GetById(employeeId).Data;
            User user = _userService.GetById(employee.UserId).Data;
            toDo.EmployeeId = employeeId;
            toDo.AppointedDate = DateTime.Now;
            toDo.IsAppointed = true;
            _toDoService.Update(toDo);
            Message message = new Message(new string[] {user.Email.ToString()},"Yeni Todo Atandı","Yeni bir todo atandı sistemden kontrol edebilirsiniz.",null);
            _emailService.SendEmail(message);
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
