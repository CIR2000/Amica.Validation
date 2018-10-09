using FluentValidation;
using Amica.Models;

namespace Amica.Validation
{
    public class ContactDetailsExValidator : AbstractValidator<ContactDetailsEx>
    {
		public ContactDetailsExValidator() 
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
