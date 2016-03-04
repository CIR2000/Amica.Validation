using Amica.vNext.Models;
using FluentValidation;

namespace Amica.vNext.Validation
{
    public class ContactValidator : AbstractValidator<Contact>
    {
		public ContactValidator()
        {
            RuleFor(contact => contact.Name).NotEmpty();
        }
    }
}
