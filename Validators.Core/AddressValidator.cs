using Amica.vNext.Models;
using FluentValidation;

namespace Amica.vNext.Validation
{
    public class AddressValidator : AbstractValidator<AddressEx>
    {
		public AddressValidator()
        {
            RuleFor(address => address.Street).Length(1, 60);
            RuleFor(address => address.Town).Length(1, 40);
            RuleFor(address => address.PostalCode).Length(1, 8);
            RuleFor(address => address.Country).Length(1, 40);
            RuleFor(address => address.StateOrProvince).Length(1, 3);
        }
    }
}
