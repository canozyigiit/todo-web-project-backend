using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
   public interface IManagerService
    {

        IDataResult<List<Manager>> GetAll();

        IResult Add(Manager manager);
        IDataResult<Manager> GetById(int managerId);

        IResult ToDoAppointe(int toDoId, int employeeId);
    }
}
