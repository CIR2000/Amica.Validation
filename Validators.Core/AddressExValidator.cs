using FluentValidation;
using Amica.vNext.Models;

namespace Amica.vNext.Validation
{
    public class AddressExValidator : AddressValidator
    {
		public AddressExValidator() 
        {
            RuleFor(address => address.Phone).Length(1, 25);
            RuleFor(address => address.Mobile).Length(1, 25);
            RuleFor(address => address.Fax).Length(1, 25);
            RuleFor(address => address.Mail).EmailAddress();
            RuleFor(address => address.PecMail).EmailAddress();
        }
    }
}
