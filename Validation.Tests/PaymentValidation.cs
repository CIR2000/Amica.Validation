using NUnit.Framework;
using Amica.Models;
using Amica.Validation;
using FluentValidation.TestHelper;

namespace Validation.Tests
{
    [TestFixture]
    public class PaymentValidation : BaseTestClass<Payment, PaymentValidator>
    {
		[Test]
		public void NameIsRequired()
        {
            AssertRequired(p => p.Name);
        }
		[Test]
		public void FirstPaymentOptionIsRequired()
        {
            AssertRequired(p => p.FirstPaymentOption);
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
            AssertRequired(p => p.FirstPaymentDate);
        }
		[Test]
		public void FirstPaymentDateMustBeValid()
        {
            foreach (var d in PaymentHelpers.FirstPaymentDates)
                validator.ShouldNotHaveValidationErrorFor(p => p.FirstPaymentDate, d.Value);
        }
		[Test]
		public void PaymentMethodHasChildValidator()
        {
            validator.ShouldHaveChildValidator(p => p.PaymentMethod, typeof(PaymentMethodValidator));
        }
        [Test]
        public void BankIdIsValidObjectId()
        {
            AssertIsValidObjectId<Payment>(x => x.BankId);
        }
        [Test]
        public void FeeIdIsValidObjectId()
        {
            AssertIsValidObjectId<Payment>(x => x.FeeId);
        }
    }
}
