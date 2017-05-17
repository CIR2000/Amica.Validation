using NUnit.Framework;
using Amica.Models;
using Amica.Validation;
using FluentValidation.TestHelper;

namespace Amica.Validation.Tests
{
    [TestFixture]
    public class PaymentValidation
    {
        private PaymentValidator validator;

		[SetUp]
		public void Init()
        {
            validator = new PaymentValidator();
        }

		[Test]
		public void NameIsRequired()
        {
            validator.ShouldHaveValidationErrorFor(p => p.Name, string.Empty);
            validator.ShouldHaveValidationErrorFor(p => p.Name,value:null);

            validator.ShouldNotHaveValidationErrorFor(p => p.Name, "payment1");
        }
		[Test]
		public void FirstPaymentOptionIsRequired()
        {
            validator.ShouldHaveValidationErrorFor(p => p.FirstPaymentOption, value:null);
        }
		[Test]
		public void FirstPaymentOptionMustBeValid()
        {
            foreach (var o in PaymentHelpers.FirstPaymentOptions)
                validator.ShouldNotHaveValidationErrorFor(p => p.FirstPaymentOption, o.Value);
        }
		[Test]
		public void FirstPaymentDateIsRequired()
        {
            validator.ShouldHaveValidationErrorFor(p => p.FirstPaymentDate, value:null);
        }
		[Test]
		public void FirstPaymentDateMustBeValid()
        {
            validator.ShouldNotHaveValidationErrorFor(p => p.FirstPaymentDate, PaymentHelpers.FirstPaymentDates[PaymentDate.DocumentDate]);
            foreach (var d in PaymentHelpers.FirstPaymentDates)
                validator.ShouldNotHaveValidationErrorFor(p => p.FirstPaymentDate, d.Value);
        }
		[Test]
		public void FeeHasChildValidator()
        {
            validator.ShouldHaveChildValidator(p => p.Fee, typeof(FeeValidator));
        }
		[Test]
		public void BankHasChildValidator()
        {
            validator.ShouldHaveChildValidator(p => p.Bank, typeof(BankValidator));
        }
		[Test]
		public void PaymentMethodHasChildValidator()
        {
            validator.ShouldHaveChildValidator(p => p.PaymentMethod, typeof(PaymentMethodValidator));
        }
    }
}
