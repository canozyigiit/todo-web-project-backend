using System;
using System.Collections.Generic;
using System.Text;
using Core;

namespace Entities.Dtos
{
   public class EmployeeDto:IDto
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
    }
}
