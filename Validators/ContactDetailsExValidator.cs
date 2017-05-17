using FluentValidation;
using Amica.Models;

namespace Amica.Validation
{
    public class ContactDetailsExValidator : AbstractValidator<ContactDetailsEx>
    {
		public ContactDetailsExValidator() 
        {
            RuleFor(address => address.Name).NotEmpty();
            RuleFor(address => address.Mail).EmailAddress();
            RuleFor(address => address.PecMail).EmailAddress();
        }
    }
}
