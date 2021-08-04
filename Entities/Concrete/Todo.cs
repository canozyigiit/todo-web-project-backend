using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;


namespace Entities.Concrete
{
   public class Todo:IEntity
    {
        public int ToDoId { get; set; }
        public String Description { get; set; }
        public int  EmployeeId { get; set; }
        public int ManagerId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime AppointedDate { get; set; }
        public bool IsAppointed { get; set; }
        public bool IsEnded { get; set; }

    }
}
