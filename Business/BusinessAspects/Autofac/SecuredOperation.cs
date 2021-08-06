using System;
using System.Collections.Generic;
using System.Text;
using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Business.BusinessAspects.Autofac
{
    //JWT
    public class SecuredOperation : MethodInterception//Yetkilendirme alt yapısını değişebilir o yüzden business
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;//Her kişi için bir httpcontext oluşturur

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))//kullanıcının rolleri arasında gereken rol var mı?
                {
                    return;//devam ettir
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
