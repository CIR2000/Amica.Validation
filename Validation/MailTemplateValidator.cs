using Amica.Models;
using FluentValidation;

namespace Amica.Validation
{
    public class MailTemplateValidator : AbstractValidator<MailTemplate>
    {
		public MailTemplateValidator()
        {
            RuleFor(x => x.FromAddress).EmailAddress();
        }
    }
}
