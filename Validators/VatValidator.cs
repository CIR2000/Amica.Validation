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

            RuleFor(vat => vat.NaturaPA)
				.Must(BeValidNaturaPA).When(vat => vat.NaturaPA != null);
        }

		private static bool BeValidNaturaPA(NaturaPA challenge)
        {
            return (
                challenge.Code != null && PAHelpers.NaturaPA.ContainsKey(challenge.Code) &&
                challenge.Description != null && PAHelpers.NaturaPA[challenge.Code].Description == challenge.Description
                );
        }
    }
}
