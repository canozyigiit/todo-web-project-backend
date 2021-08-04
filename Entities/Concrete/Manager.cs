using System;
using System.Collections.Generic;
using System.Text;
using Entities.Abstract;

namespace Entities.Concrete
{
  public  class Manager:IEntity
    {
        public int EmployerId { get; set; }
        public String UserId { get; set; }
     
    }
}
