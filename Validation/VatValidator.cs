using Amica.Models;
using Amica.Models.ItalianPA;
using FluentValidation;

namespace Amica.Validation
{
    public class VatValidator : AbstractValidator<Vat>
    {
        public VatValidator()
        {
            RuleFor(vat => vat.Name).NotEmpty();
            RuleFor(vat => vat.Code).NotEmpty();

            RuleFor(vat => vat.VatExemption).Must(BeValidNaturaPA);
        }

		private static bool BeValidNaturaPA(VatExemption challenge)
        {
            return (
                challenge is null ||
                (challenge.Code != null && ItalianPAHelpers.VatExemption.ContainsKey(challenge.Code) &&
                challenge.Description != null && ItalianPAHelpers.VatExemption[challenge.Code].Description == challenge.Description
                ));
        }
    }
}
