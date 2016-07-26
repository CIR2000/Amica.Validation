using Amica.vNext.Models;
using Amica.vNext.Models.ItalianPA;
using FluentValidation;

namespace Amica.vNext.Validation
{
    public class PaymentMethodValidator : AbstractValidator<PaymentMethod>
    {
		public PaymentMethodValidator()
        {
            RuleFor(method => method.Name).NotEmpty();

            RuleFor(method => method.ModalitaPagamentoPA)
				.Must(BeValidModalitaPagamentoPA).When(method => method.ModalitaPagamentoPA != null);
        }

		private static bool BeValidModalitaPagamentoPA(ModalitaPagamentoPA challenge)
        {
            return challenge.Code != null && PAHelpers.ModalitaPagamentoPA.ContainsKey(challenge.Code);
        }
    }
}
