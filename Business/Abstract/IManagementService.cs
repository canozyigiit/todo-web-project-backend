using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;

namespace Business.Abstract
{
   public interface IManagementService
    {
        IResult MakeUserEmployee(string mail,string position);
        IResult MakeUserManager(string mail);
        IResult MakeUserDirector(string mail);
        IResult ToDoAppointe(int toDoId, int employeeId);
    }
}
