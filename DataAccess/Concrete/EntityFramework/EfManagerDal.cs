using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfManagerDal : EfEntityRepositoryBase<Manager, TodoContext>,IManagerDal
    {
        public List<ManagerDto> GetAllManagerDetails()
        {
            using (TodoContext context = new TodoContext())
            {
                var result = from m in context.Managers
                    join u in context.Users on m.UserId equals u.Id
                    join c in context.UserOperationClaims on m.UserId equals c.UserId


                    select new ManagerDto()
                    {
                        ManagerId = m.ManagerId,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Email = u.Email,
                        claim = c.OperationClaimId
                    };
                return result.ToList();



            }
        }
    }
}
