using Amica.Models;
using Amica.Models.ItalianPA;
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
            return (
                challenge.Code != null && PAHelpers.ModalitaPagamentoPA.ContainsKey(challenge.Code) &&
                challenge.Description != null && PAHelpers.ModalitaPagamentoPA[challenge.Code].Description == challenge.Description
                );
        }
    }
}
