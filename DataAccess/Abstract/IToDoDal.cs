using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Abstract
{
    //DataAccesLayer
   public interface IToDoDal:IEntityRepository<Todo>
   {
       List<ToDoDto> GetToDoDetails();
   }
}
