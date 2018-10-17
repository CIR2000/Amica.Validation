using Amica.Models;
using FluentValidation;

namespace Amica.Validation
{
    public class SalesSettingsValidator : AbstractValidator<SalesSettings>
    {
        public SalesSettingsValidator()
        {
            RuleFor(x => x.EinvoiceId).MinimumLength(6).MaximumLength(7).When(x => x.EinvoiceId!=null);
        }
    }
}
