using Core;
using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Text;

namespace Entities.Dtos
{
   public class ToDoDto:IDto
    {
        public int  ToDoId { get; set; }
        public string Description { get; set; }
        public int? EmployeeId { get; set; }
        public int ManagerId { get; set; }
        public string? EmployeeFirstName { get; set; }
        public string? EmployeeLastName { get; set; }
        public string ManagerFirstName { get; set; }
        public string ManagerLastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? AppointedDate { get; set; }
        public bool IsAppointed { get; set; }
        public bool? IsEnded { get; set; }


    }
}
