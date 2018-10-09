using FluentValidation;
using Amica.Models;

namespace Amica.Validation
{
    public class AddressExValidator : AbstractValidator<AddressEx>
    {
		public AddressExValidator() 
        {
            RuleFor(address => address.Mail)
                .Matches(Static.MailRegex)
                .WithLocalizedMessage(typeof(ErrorMessages), nameof(ErrorMessages.MailAddressError));
            RuleFor(address => address.PecMail)
                .Matches(Static.MailRegex)
                .WithLocalizedMessage(typeof(ErrorMessages), nameof(ErrorMessages.MailAddressError));
        }
    }
}
