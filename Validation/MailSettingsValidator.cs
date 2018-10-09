using Amica.Models;
using FluentValidation;

namespace Amica.Validation
{
    public class MailSettingsValidator : AbstractValidator<MailSettings>
    {
		public MailSettingsValidator()
        {
            RuleForEach(x => x.Template).SetValidator(new MailTemplateValidator());
        }
    }
}
