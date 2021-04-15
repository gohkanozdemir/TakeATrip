using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.CarName).NotEmpty();
            RuleFor(c => c.CarName).MinimumLength(2);
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(200).When(c => c.CategoryId == 4);
            // RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Urunler A harfi ile baslamali");;  // ---> olmayan bir kural yazmak istedigimizde yazilacak olan kod
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
