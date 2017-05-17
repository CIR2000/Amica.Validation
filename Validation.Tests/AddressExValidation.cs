using NUnit.Framework;
using Amica.Validation;
using FluentValidation.TestHelper;

namespace Amica.Validation.Tests
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
		public void MailMustBeValid() {
			validator.ShouldHaveValidationErrorFor(c => c.Mail, string.Empty);
            validator.ShouldHaveValidationErrorFor(c => c.Mail, "fakeemail");
            validator.ShouldHaveValidationErrorFor(c => c.Mail, "mail@mail");
            validator.ShouldHaveValidationErrorFor(c => c.Mail, "@mail.it");
            validator.ShouldHaveValidationErrorFor(c => c.Mail, @"test\@test@iana.org");
			validator.ShouldNotHaveValidationErrorFor(c => c.Mail, "mail@mail.it.com"); 

			validator.ShouldNotHaveValidationErrorFor(c => c.Mail, "mail@mail.it");
            validator.ShouldNotHaveValidationErrorFor(c => c.Mail, value:null);
        }
		[Test]
		public void PecMailMustBeValid() {
			validator.ShouldHaveValidationErrorFor(c => c.PecMail, string.Empty);
            validator.ShouldHaveValidationErrorFor(c => c.PecMail, "fakeemail");
            validator.ShouldHaveValidationErrorFor(c => c.PecMail, "mail@mail");
            validator.ShouldHaveValidationErrorFor(c => c.PecMail, "@mail.it");
            validator.ShouldHaveValidationErrorFor(c => c.PecMail, "@mail");
			validator.ShouldNotHaveValidationErrorFor(c => c.PecMail, "mail@mail.it.com"); 

			validator.ShouldNotHaveValidationErrorFor(c => c.PecMail, "mail@mail.it"); 
            validator.ShouldNotHaveValidationErrorFor(c => c.PecMail, value:null);
        }

    }
}
