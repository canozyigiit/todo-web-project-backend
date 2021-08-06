using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface IEmployeeService
    {

        IDataResult<List<Employee>> GetAll();
      
        IResult Add(Employee employee);
        IDataResult<Employee> GetById(int employeeId);

       

    }
}
