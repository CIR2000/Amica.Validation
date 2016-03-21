using Amica.vNext.Models;
using Amica.vNext.Models.ItalianPA;
using FluentValidation;

namespace Amica.vNext.Validation
{
    public class PaymentOptionValidator : AbstractValidator<PaymentOption>
    {
		public PaymentOptionValidator()
        {
            RuleFor(option => option.Name).NotEmpty();

            RuleFor(option => option.ModalitaPagamentoPA)
				.Must(BeValidModalitaPagamentoPA).When(option => option.ModalitaPagamentoPA != null);
        }

		private static bool BeValidModalitaPagamentoPA(ModalitaPagamentoPA challenge)
        {
            return challenge.Code != null && PACollections.ModalitaPagamentoPA.ContainsKey(challenge.Code);
        }
    }
}
