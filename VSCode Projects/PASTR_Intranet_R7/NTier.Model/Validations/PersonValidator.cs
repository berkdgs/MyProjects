using FluentValidation;
using NTier.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NTier.Model.Validations
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Ad alanı boş geçilemez!");
            RuleFor(x => x.LastName).NotNull().WithMessage("Soyad alanı boş geçilemez!");
            RuleFor(x => x.BirthDate).NotNull().WithMessage("Doğum Tarihi alanı boş geçilemez!");
            RuleFor(x => x.TCKN).Length(11, 11).WithMessage("T.C. Kimlik no 11 karekterden farklı olamaz!");
        }

    }
}
