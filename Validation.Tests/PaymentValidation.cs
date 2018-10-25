using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amica.Models;
using Amica.Validation;
using FluentValidation.TestHelper;

namespace Validation.Tests
{
    [TestClass]
    public class PaymentValidation : BaseTestClass<Payment, PaymentValidator>
    {
        [TestMethod]
        public void NameIsRequired()
        {
            AssertRequired(p => p.Name);
        }
        [TestMethod]
        public void FirstPaymentOptionIsRequired()
        {
            AssertRequired(p => p.FirstPaymentOption);
        }
        [TestMethod]
        public void FirstPaymentOptionMustBeValid()
        {
            foreach (var o in PaymentHelpers.FirstPaymentOptions)
                validator.ShouldNotHaveValidationErrorFor(p => p.FirstPaymentOption, o);
        }
        [TestMethod]
        public void FirstPaymentDateIsRequired()
        {
            AssertRequired(p => p.FirstPaymentDate);
        }
        [TestMethod]
        public void FirstPaymentDateMustBeValid()
        {
            foreach (var d in PaymentHelpers.FirstPaymentDates)
                validator.ShouldNotHaveValidationErrorFor(p => p.FirstPaymentDate, d);
        }
        [TestMethod]
        public void PaymentMethodHasChildValidator()
        {
            validator.ShouldHaveChildValidator(p => p.PaymentMethod, typeof(PaymentMethodValidator));
        }
        [TestMethod]
        public void BankIdIsValidObjectId()
        {
            AssertIsValidObjectId<Payment>(x => x.BankId);
        }
        [TestMethod]
        public void FeeIdIsValidObjectId()
        {
            AssertIsValidObjectId<Payment>(x => x.FeeId);
        }
    }
}
