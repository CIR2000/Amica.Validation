using Amica.vNext.Models;
using FluentValidation;

namespace Amica.vNext.Validation
{
	public class NameFieldValidator : AbstractValidator<AddressExWithName>
    {
        public NameFieldValidator()
        {
            RuleFor(address => address.Name).Length(1, 60);
        }

    }

    public class AddressExWithNameValidator : AbstractValidator<AddressExWithName>
    {
		public AddressExWithNameValidator()
        {
            AddRule(new CompositeValidatorRule(new AddressExValidator(), new NameFieldValidator()));
        }
    }
}
