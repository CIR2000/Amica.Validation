using Amica.Models;
using FluentValidation;

namespace Amica.Validation
{
    public class MailSettingsValidator : AbstractValidator<MailSettings>
    {
		public MailSettingsValidator()
        {
            RuleFor(x => x.Template).SetCollectionValidator(new MailTemplateValidator());
        }
    }
}
