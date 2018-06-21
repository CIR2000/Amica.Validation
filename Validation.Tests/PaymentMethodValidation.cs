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
		public void PublicAdministrationCodeIsOptional()
        {
            AssertOptional(o => o.PublicAdministrationCode);
        }

		[TestMethod]
		public void PublicAdministrationCodeMustBeValid()
        {
            validator.ShouldHaveValidationErrorFor( o => o.PublicAdministrationCode, "hello");

            foreach (var n in PaymentHelpers.PaymentMethods)
                validator.ShouldNotHaveValidationErrorFor(o => o.PublicAdministrationCode, n.PublicAdministrationCode);
        }


    }
}
