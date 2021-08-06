using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.Utilities.Security.JWT
{
   public interface ITokenHelper
   {
       AccessToken CreateToken(User user, List<OperationClaim> operationClaims);//Kullanıcının claimlerini içeren token verir
   }
}
