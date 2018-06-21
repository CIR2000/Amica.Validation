using Amica.Validation;
using Amica.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Validation.Tests
{
    [TestClass]
    public class AddressExValidation : BaseTestClass<AddressEx, AddressExValidator>
    {
		[TestMethod]
		public void MailMustBeValid()
        {
            AssertValidEmail(c => c.Mail);
        }
		[TestMethod]
		public void PecMailMustBeValid()
        {
            AssertValidEmail(c => c.PecMail);
        }

    }
}
