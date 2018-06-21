using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amica.Validation;
using Amica.Models.Documents;
using FluentValidation.TestHelper;

namespace Validation.Tests
{
    [TestClass]
    public class ShippingValidation : BaseTestClass<Shipping, ShippingValidator>
    {
		[TestMethod]
		public void CourierHasChildValidator()
        {
            validator.ShouldHaveChildValidator(s => s.Courier, typeof(ContactDetailsExValidator));
        }
        [TestMethod]
        public void CourierIsRequiredWhenTransportModeIsSetToCourier()
        {
            challenge.TransportMode = DocumentHelpers.TransportModes[DocumentTransportMode.Courier];
            validator.ShouldHaveValidationErrorFor(s => s.Courier, challenge).WithErrorCode("NotNullValidator");
            challenge.TransportMode = DocumentHelpers.TransportModes[DocumentTransportMode.Sender];
            validator.ShouldNotHaveValidationErrorFor(s => s.Courier, challenge);
        }
		[TestMethod]
		public void TermsHasChildValidator()
        {
            validator.ShouldHaveChildValidator(s => s.Terms, typeof(ShippingTermValidator));
        }
    }
}
