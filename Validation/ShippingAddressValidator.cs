using FluentValidation;
using Amica.Models;

namespace Amica.Validation
{
    public class ShippingAddressValidator : AbstractValidator<ShippingAddress>
    {
		public ShippingAddressValidator() 
        {
            RuleFor(address => address.Name).NotEmpty();
            RuleFor(address => address.Mail)
                .Matches(Static.MailRegex)
                .WithLocalizedMessage(typeof(ErrorMessages), nameof(ErrorMessages.MailAddressError));
            RuleFor(address => address.PecMail)
                .Matches(Static.MailRegex)
                .WithLocalizedMessage(typeof(ErrorMessages), nameof(ErrorMessages.MailAddressError));
        }
    }
}
