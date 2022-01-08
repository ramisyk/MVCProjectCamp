using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Boş Bırakılamaz.");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadı Boş Bırakılamaz.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında Boş Bırakılamaz");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girin");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen 50 karaktere kadar bir değer girin");
            //RuleFor(x => x.WriterAbout).Must(str => str.ToLower().Contains("a")).WithMessage("Yazar Hakkında Bilgisi 'a/A' Harfi İçermelidir."); 
        }
    }
}
