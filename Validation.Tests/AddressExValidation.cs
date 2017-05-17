using NUnit.Framework;
using Amica.Validation;
using Amica.Models;

namespace Validation.Tests
{
    [TestFixture]
    public class AddressExValidation : BaseTestClass<AddressEx, AddressExValidator>
    {
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
