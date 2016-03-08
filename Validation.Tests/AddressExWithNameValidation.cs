using NUnit.Framework;
using Amica.vNext.Validation;
using FluentValidation.TestHelper;
using Amica.vNext.Models;
using System.Linq.Expressions;
using System;

namespace Validation.Tests
{
    [TestFixture]
    public class AddressExWithNameValidation : AddressAndAddressExValidation
    {
        private AddressExWithNameValidator validator;

        [SetUp]
        public new void Init()
        {
            validator = new AddressExWithNameValidator();
        }

        [Test]
		public void Name() {
            var length = 60;
			validator.ShouldHaveValidationErrorFor(c => c.Street, string.Empty);
            validator.ShouldHaveValidationErrorFor(c => c.Street, new string('A', length+1));

			validator.ShouldNotHaveValidationErrorFor(c => c.Street, null as string); 
            validator.ShouldNotHaveValidationErrorFor(c => c.Street, "A");
            validator.ShouldNotHaveValidationErrorFor(c => c.Street, new string('A', length));
        }
    }
}
