using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)//validator tipi
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//çalışma anında validatore ait Instance oluştur
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//validatorun çalışma tipini bul
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//metotda validatorun tipine eşit olan paremetleri bul
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);//doğrula
            }
        }
    }
}
