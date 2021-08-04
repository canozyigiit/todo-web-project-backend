using Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
   public class ToDoDto:IDto
    {
        public int  ToDoId { get; set; }
        public string Description { get; set; }
        public string EmployeeName { get; set; }
       
    }
}
