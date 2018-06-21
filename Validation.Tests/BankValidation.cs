using Amica.Validation;
using FluentValidation.TestHelper;
using Amica.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Validation.Tests
{
    // Can't inherit from BastTestClass because BankValidator has an interface as generic argument.

    [TestClass]
    public class BankValidation 
    {
        private BankValidator validator;
        protected Bank challenge;

        [TestInitialize]
        public void Init()
        {
            validator = new BankValidator();
            challenge = new Bank();
        }


		[TestMethod]
		public void NameIsRequired()
        {
            challenge.Name = string.Empty;
            Assert.IsTrue(HasValidationError("Name"));
            challenge.Name = null;
            Assert.IsTrue(HasValidationError("Name"));
            challenge.Name = "a name";
            Assert.IsFalse(HasValidationError("Name"));
        }
        [TestMethod]
        public void IbanCodeMustBeValid()
        {
            challenge.IbanCode = string.Empty;
            Assert.IsTrue(HasValidationError("IbanCode"));
            challenge.IbanCode = "ABC";
            Assert.IsTrue(HasValidationError("IbanCode"));
            challenge.IbanCode = "88T1927501600CC0010110180";
            Assert.IsTrue(HasValidationError("IbanCode"));

            challenge.IbanCode = "IT88T1927501600CC0010110180";
            Assert.IsFalse(HasValidationError("IbanCode"));
            challenge.IbanCode = null;
            Assert.IsFalse(HasValidationError("IbanCode"));
        }

        [TestMethod]
        public void SwitCodeMustBeValid()
        {

            challenge.BicSwiftCode = string.Empty;
            Assert.IsTrue(HasValidationError("BicSwiftCode"));
            challenge.BicSwiftCode = "A";
            Assert.IsTrue(HasValidationError("BicSwiftCode"));
            challenge.BicSwiftCode = "12345678901";
            Assert.IsTrue(HasValidationError("BicSwiftCode"));

            challenge.BicSwiftCode = null;
            Assert.IsFalse(HasValidationError("BicSwiftCode"));
            challenge.BicSwiftCode = "ABCOITMM";
            Assert.IsFalse(HasValidationError("BicSwiftCode"));
            challenge.BicSwiftCode = "ICRAITRRL90";
            Assert.IsFalse(HasValidationError("BicSwiftCode"));
            challenge.BicSwiftCode = "CRGEITGG183";
            Assert.IsFalse(HasValidationError("BicSwiftCode"));
        }
        private bool HasValidationError(string propertyName)
        {
            var r = validator.Validate(challenge);
            var found = false;
            foreach (var item in r.Errors)
            {
                if (item.PropertyName == propertyName)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

    }
}
