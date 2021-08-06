using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;


namespace Entities.Concrete
{
   public class Employee:IEntity
    {
        public int EmployeeId { get; set; }
        public int UserId { get; set; }
        public string Position { get; set; }
     
    }
}
