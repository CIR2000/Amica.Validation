using FluentValidation;
using Amica.Models;

namespace Amica.vNext.Validation
{
    public class AddressExValidator : AbstractValidator<AddressEx>
    {
		public AddressExValidator() 
        {
            RuleFor(address => address.Mail).EmailAddress();
            RuleFor(address => address.PecMail).EmailAddress();
        }
    }
}
