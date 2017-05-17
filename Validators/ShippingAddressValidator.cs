using FluentValidation;
using Amica.Models;

namespace Amica.Validation
{
    public class ShippingAddressValidator : AbstractValidator<ShippingAddress>
    {
		public ShippingAddressValidator() 
        {
            RuleFor(address => address.Name).NotEmpty();
            RuleFor(address => address.Mail).EmailAddress();
            RuleFor(address => address.PecMail).EmailAddress();
        }
    }
}
