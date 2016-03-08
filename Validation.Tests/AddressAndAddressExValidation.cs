using NUnit.Framework;
using Amica.vNext.Validation;
using FluentValidation.TestHelper;
using Amica.vNext.Models;
using System.Linq.Expressions;
using System;

namespace Validation.Tests
{
    [TestFixture]
    public class AddressAndAddressExValidation
    {
        private AddressExValidator validator;

		[SetUp]
		public void Init()
        {
            validator = new AddressExValidator();
        }

		[Test]
		public void Street() {
            var length = 60;
			validator.ShouldHaveValidationErrorFor(c => c.Street, string.Empty);
            validator.ShouldHaveValidationErrorFor(c => c.Street, new string('A', length+1));

			validator.ShouldNotHaveValidationErrorFor(c => c.Street, null as string); 
            validator.ShouldNotHaveValidationErrorFor(c => c.Street, "A");
            validator.ShouldNotHaveValidationErrorFor(c => c.Street, new string('A', length));
        }

		[Test]
		public void Town() {
            var length = 40;
			validator.ShouldHaveValidationErrorFor(c => c.Town, string.Empty);
            validator.ShouldHaveValidationErrorFor(c => c.Town, new string('A', length+1));

			validator.ShouldNotHaveValidationErrorFor(c => c.Town, null as string); 
            validator.ShouldNotHaveValidationErrorFor(c => c.Town, "A");
            validator.ShouldNotHaveValidationErrorFor(c => c.Town, new string('A', length));
        }

		[Test]
		public void PostalCode() {
            var length = 8;
			validator.ShouldHaveValidationErrorFor(c => c.PostalCode, string.Empty);
            validator.ShouldHaveValidationErrorFor(c => c.PostalCode, new string('A', length+1));

			validator.ShouldNotHaveValidationErrorFor(c => c.PostalCode, null as string); 
            validator.ShouldNotHaveValidationErrorFor(c => c.PostalCode, "A");
            validator.ShouldNotHaveValidationErrorFor(c => c.PostalCode, new string('A', length));
        }

		[Test]
		public void Country() {
            var length = 40;
			validator.ShouldHaveValidationErrorFor(c => c.Country, string.Empty);
            validator.ShouldHaveValidationErrorFor(c => c.Country, new string('A', length+1));

			validator.ShouldNotHaveValidationErrorFor(c => c.Country, null as string); 
            validator.ShouldNotHaveValidationErrorFor(c => c.Country, "A");
            validator.ShouldNotHaveValidationErrorFor(c => c.Country, new string('A', length));
        }

		[Test]
		public void StateOrProvince() {
            var length = 3;
			validator.ShouldHaveValidationErrorFor(c => c.StateOrProvince, string.Empty);
            validator.ShouldHaveValidationErrorFor(c => c.StateOrProvince, new string('A', length+1));

			validator.ShouldNotHaveValidationErrorFor(c => c.StateOrProvince, null as string); 
            validator.ShouldNotHaveValidationErrorFor(c => c.StateOrProvince, "A");
            validator.ShouldNotHaveValidationErrorFor(c => c.StateOrProvince, new string('A', length));
        }
		[Test]
		public void Phone() {
            var length = 25;
			validator.ShouldHaveValidationErrorFor(c => c.Phone, string.Empty);
            validator.ShouldHaveValidationErrorFor(c => c.Phone, new string('A', length+1));

			validator.ShouldNotHaveValidationErrorFor(c => c.Phone, null as string); 
            validator.ShouldNotHaveValidationErrorFor(c => c.Phone, "A");
            validator.ShouldNotHaveValidationErrorFor(c => c.Phone, new string('A', length));
        }
		[Test]
		public void Mobile() {
            var length = 25;
			validator.ShouldHaveValidationErrorFor(c => c.Mobile, string.Empty);
            validator.ShouldHaveValidationErrorFor(c => c.Mobile, new string('A', length+1));

			validator.ShouldNotHaveValidationErrorFor(c => c.Mobile, null as string); 
            validator.ShouldNotHaveValidationErrorFor(c => c.Mobile, "A");
            validator.ShouldNotHaveValidationErrorFor(c => c.Mobile, new string('A', length));
        }
		[Test]
		public void Fax() {
            var length = 25;
			validator.ShouldHaveValidationErrorFor(c => c.Fax, string.Empty);
            validator.ShouldHaveValidationErrorFor(c => c.Fax, new string('A', length+1));

			validator.ShouldNotHaveValidationErrorFor(c => c.Fax, null as string); 
            validator.ShouldNotHaveValidationErrorFor(c => c.Fax, "A");
            validator.ShouldNotHaveValidationErrorFor(c => c.Fax, new string('A', length));
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
