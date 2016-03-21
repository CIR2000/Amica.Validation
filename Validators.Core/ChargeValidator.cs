using Amica.vNext.Models;
using Amica.vNext.Models.ItalianPA;
using FluentValidation;

namespace Amica.vNext.Validation
{
    public class ChargeValidator : AbstractValidator<Charge>
    {
		public ChargeValidator()
        {
            RuleFor(charge => charge.Name).NotEmpty();
            RuleFor(charge => charge.Vat).SetValidator(new VatValidator());
        }

		private static bool BeValidModalitaPagamentoPA(ModalitaPagamentoPA challenge)
        {
            return challenge.Code != null && PACollections.ModalitaPagamentoPA.ContainsKey(challenge.Code);
        }
    }
}
