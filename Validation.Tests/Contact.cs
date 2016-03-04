using NUnit.Framework;
using Amica.vNext.Validation;
using FluentValidation.TestHelper;

namespace Validation.Tests
{
    [TestFixture]
    public class ContactValidation
    {
        private ContactValidator validator;

		[SetUp]
		public void Init()
        {
            validator = new ContactValidator();
        }

		[Test]
		public void NameCannotBeEmpty() {
			validator.ShouldHaveValidationErrorFor(c => c.Name, null as string); 
			validator.ShouldHaveValidationErrorFor(c => c.Name, string.Empty); 

			validator.ShouldNotHaveValidationErrorFor(c => c.Name, "Jeremy");
		}
    }
}
