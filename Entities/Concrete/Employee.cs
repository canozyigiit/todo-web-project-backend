using System;
using System.Collections.Generic;
using System.Text;
using Entities.Abstract;

namespace Entities.Concrete
{
   public class Employee:IEntity
    {
        public int EmployeeId { get; set; }
        public String UserId { get; set; }
        public String Position { get; set; }
     
    }
}
