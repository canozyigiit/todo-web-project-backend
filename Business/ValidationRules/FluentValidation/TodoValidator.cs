using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
  public class TodoValidator:AbstractValidator<Todo>
    {
        public TodoValidator()
        {
            RuleFor(t => t.Description).MinimumLength(10).WithMessage("Lütfen tanımı on karakterden büyük veriniz.");
            RuleFor(t => t.Description).NotEmpty();
            RuleFor(t => t.ManagerId).NotEmpty();
            RuleFor(t => t.CreatedDate).NotEmpty();
         
        }
    }
}
