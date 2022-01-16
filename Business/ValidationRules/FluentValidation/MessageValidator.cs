using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Kategori Adı Boş Bırakılamaz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Açıklama Boş Bırakılamaz");
            RuleFor(x => x.MessageContent).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girin");
            RuleFor(x => x.MessageContent).MaximumLength(20).WithMessage("Lütfen 20 karaktere kadar bir değer girin");

        }
    }
}
