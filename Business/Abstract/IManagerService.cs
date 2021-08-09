using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;

namespace Business.Abstract
{
   public interface IManagerService
    {

        IDataResult<List<Manager>> GetAll();

        IResult Add(Manager manager);
        IDataResult<Manager> GetById(int managerId);
        IDataResult<Manager> GetByUserId(int userId);
        IDataResult<List<ManagerDto>> GetAllManagerDetails();
       
    }
}
