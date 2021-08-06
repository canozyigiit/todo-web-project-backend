﻿using System;
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
   public class EmployeeManager:IEmployeeService
   {

       private IEmployeeDal _employeeDal;

       public EmployeeManager(IEmployeeDal employeeDal)
       {
           this._employeeDal = employeeDal;
       }
        public IDataResult<List<Employee>> GetAll()
        {
            return new SuccessDataResult<List<Employee>>(this._employeeDal.GetAll(), Messages.EmployeeListed);
        }

        public IDataResult<List<EmployeeDto>> GetAllDetails()
        {
            return new SuccessDataResult<List<EmployeeDto>>(this._employeeDal.GetallEmployeeDtos(), Messages.EmployeeListed);
        }

        public IResult Add(Employee employee)
        {
            _employeeDal.Add(employee);
            return new SuccessResult(Messages.EmployeeAdded);
        }

        public IDataResult<Employee> GetById(int employeeId)
        {
            return new SuccessDataResult<Employee>(_employeeDal.Get(e => e.EmployeeId == employeeId), Messages.EmployeeFound);
        }
    }
}
