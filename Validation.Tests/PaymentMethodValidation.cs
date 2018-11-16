using Amica.Models;
using Amica.Validation;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Validation.Tests
{
    [TestClass]
    public class PaymentMethodValidation : BaseTestClass<Amica.Models.PaymentMethod, PaymentMethodValidator>
    {
        [TestMethod]
        public void NameIsRequired()
        {
            AssertRequired(o => o.Name);
        }

        [TestMethod]
        public void CodeIsRequired()
        {
            AssertRequired(o => o.Code);
        }

        [TestMethod]
        public void CodeMustBeValid()
        {
            validator.ShouldHaveValidationErrorFor(o => o.Code, "hello");

            foreach (var n in PaymentHelpers.PaymentMethods)
                validator.ShouldNotHaveValidationErrorFor(o => o.Code, n.Code);
        }

    }
}