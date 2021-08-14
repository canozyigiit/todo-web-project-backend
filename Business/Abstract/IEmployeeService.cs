using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
   public interface IEmployeeService
    {

        IDataResult<List<Employee>> GetAll();
        IDataResult<List<EmployeeDto>> GetAllDetails();
        IResult Add(Employee employee);
        IDataResult<Employee> GetById(int employeeId);

        IDataResult<Employee> GetByUserId(int id);

    }
}
