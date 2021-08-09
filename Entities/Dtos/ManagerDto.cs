using System;
using System.Collections.Generic;
using System.Text;
using Core;

namespace Entities.Dtos
{
   public class ManagerDto:IDto
    {
        public int ManagerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? claim { get; set; }
      
    }
}
