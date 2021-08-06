using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
   public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)//uygulama çalışınca çalışır
        {
            builder.RegisterType<ToDoManager>().As<IToDoService>().SingleInstance();
            builder.RegisterType<EfToDoDal>().As<IToDoDal>().SingleInstance();

            builder.RegisterType<ManagerMng>().As<IManagerService>().SingleInstance();
            builder.RegisterType<EfManagerDal>().As<IManagerDal>().SingleInstance();

            builder.RegisterType<EmployeeManager>().As<IEmployeeService>().SingleInstance();
            builder.RegisterType<EfEmployeeDal>().As<IEmployeeDal>().SingleInstance();



            //aspecti var mı?
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();//çalışan uygulama

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()//implemente edilmiş interfaceleri bul
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()//onlar için AIS çağır
                }).SingleInstance();

        }
    }
}
