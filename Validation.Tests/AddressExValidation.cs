using NUnit.Framework;
using Amica.vNext.Validation;
using FluentValidation.TestHelper;

namespace Validation.Tests
{
    [TestFixture]
    public class AddressExValidation
    {
        private AddressExValidator validator;

		[SetUp]
		public void Init()
        {
            validator = new AddressExValidator();
        }

		[Test]
		public void Mail() {
			validator.ShouldHaveValidationErrorFor(c => c.Mail, string.Empty);
            validator.ShouldHaveValidationErrorFor(c => c.Mail, "fakeemail");
            validator.ShouldHaveValidationErrorFor(c => c.Mail, "mail@mail");
            validator.ShouldHaveValidationErrorFor(c => c.Mail, "@mail.it");
            validator.ShouldHaveValidationErrorFor(c => c.Mail, "@mail");
			validator.ShouldNotHaveValidationErrorFor(c => c.Mail, "mail@mail.it.com"); 

			validator.ShouldNotHaveValidationErrorFor(c => c.Mail, "mail@mail.it"); 
        }
		[Test]
		public void PecMail() {
			validator.ShouldHaveValidationErrorFor(c => c.PecMail, string.Empty);
            validator.ShouldHaveValidationErrorFor(c => c.PecMail, "fakeemail");
            validator.ShouldHaveValidationErrorFor(c => c.PecMail, "mail@mail");
            validator.ShouldHaveValidationErrorFor(c => c.PecMail, "@mail.it");
            validator.ShouldHaveValidationErrorFor(c => c.PecMail, "@mail");
			validator.ShouldNotHaveValidationErrorFor(c => c.PecMail, "mail@mail.it.com"); 

			validator.ShouldNotHaveValidationErrorFor(c => c.PecMail, "mail@mail.it"); 
        }

    }
}
