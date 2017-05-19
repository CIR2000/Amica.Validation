using NUnit.Framework;
using Amica.Validation;
using FluentValidation.TestHelper;
using Amica.Models.Documents;

namespace Validation.Tests
{
    [TestFixture]
    public class DocumentPaymentValidation : BaseTestClass<DocumentPayment, DocumentPaymentValidator>
    {
		[Test]
		public void CurrentHasChildValidator()
        {
            validator.ShouldHaveChildValidator(dp => dp.Current, typeof(PaymentValidator));
        }
    }
}
