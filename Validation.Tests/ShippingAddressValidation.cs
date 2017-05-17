using NUnit.Framework;
using Amica.Validation;
using Amica.Models;

namespace Validation.Tests
{
    [TestFixture]
    public class ShippingAddressValidation : BaseTestClass<ShippingAddress, ShippingAddressValidator>
    {
        [Test]
        public void NameIsRequired()
        {
            AssertRequired(c => c.Name);
        }
		[Test]
		public void MailMustBeValid()
        {
            AssertValidEmail(c => c.Mail);
        }
		[Test]
		public void PecMailMustBeValid()
        {
            AssertValidEmail(c => c.PecMail);
        }

    }
}
