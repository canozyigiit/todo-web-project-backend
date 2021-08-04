using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
   public class ToDoManager:IToDoService
   {
       private IToDoDal _toDoDal;

       public ToDoManager(IToDoDal toDoDal)
       {
           _toDoDal = toDoDal;
       }
        public List<Todo> GetAll()
        {
           return _toDoDal.GetAll();
        }

        public List<Todo> GetAllByEmployeeId(int id)
        {
            return _toDoDal.GetAll(t => t.EmployeeId == id);
        }

        public List<Todo> GetAllByManagerId(int id)
        {
            return _toDoDal.GetAll(t => t.ManagerId == id);
        }

        public List<Todo> GetAllIsEndedFalse()
        {
            return _toDoDal.GetAll(t => t.IsEnded == false);
        }

        public List<Todo> GetAllIsAppointed(bool isAppointed)
        {
            return _toDoDal.GetAll(t => t.IsAppointed == isAppointed);
        }
   }
}
