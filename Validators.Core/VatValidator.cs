using Amica.vNext.Models;
using Amica.vNext.Models.ItalianPA;
using FluentValidation;

namespace Amica.vNext.Validation
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
            return challenge.Code != null && PAHelpers.NaturaPA.ContainsKey(challenge.Code);
        }
    }
}
