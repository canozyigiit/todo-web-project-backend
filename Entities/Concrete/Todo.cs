using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;


namespace Entities.Concrete
{
   public class Todo:IEntity
    {
        public int ToDoId { get; set; }
        public string Description { get; set; }
        public int? EmployeeId { get; set; } = null;
        public int ManagerId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? AppointedDate { get; set; } = null;
        public bool IsAppointed { get; set; } = false;
        public bool IsEnded { get; set; } = false;

    }
}
