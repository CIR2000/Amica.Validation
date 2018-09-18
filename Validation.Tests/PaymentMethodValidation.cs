using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amica.Validation;
using FluentValidation.TestHelper;
using Amica.Models;

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
		public void CodeIsOptional()
        {
            AssertOptional(o => o.Code);
        }

		[TestMethod]
		public void CodeMustBeValid()
        {
            validator.ShouldHaveValidationErrorFor( o => o.Code, "hello");

            foreach (var n in PaymentHelpers.PaymentMethods)
                validator.ShouldNotHaveValidationErrorFor(o => o.Code, n.Code);
        }


    }
}
