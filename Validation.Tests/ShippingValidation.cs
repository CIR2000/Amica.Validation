using NUnit.Framework;
using Amica.Validation;
using Amica.Models.Documents;
using FluentValidation.TestHelper;

namespace Validation.Tests
{
    [TestFixture]
    public class ShippingValidation : BaseTestClass<Shipping, ShippingValidator>
    {
		[Test]
		public void CourierHasChildValidator()
        {
            validator.ShouldHaveChildValidator(s => s.Courier, typeof(ContactDetailsExValidator));
        }
        [Test]
        public void CourierIsRequiredWhenTransportModeIsSetToCourier()
        {
            challenge.TransportMode = DocumentHelpers.TransportModes[DocumentTransportMode.Courier];
            validator.ShouldHaveValidationErrorFor(s => s.Courier, challenge).WithErrorCode("NotNullValidator");
            challenge.TransportMode = DocumentHelpers.TransportModes[DocumentTransportMode.Sender];
            validator.ShouldNotHaveValidationErrorFor(s => s.Courier, challenge);
        }
		[Test]
		public void TermsHasChildValidator()
        {
            validator.ShouldHaveChildValidator(s => s.Terms, typeof(ShippingTermValidator));
        }
    }
}
