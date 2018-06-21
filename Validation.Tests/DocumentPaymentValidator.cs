using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amica.Validation;
using FluentValidation.TestHelper;
using Amica.Models.Documents;

namespace Validation.Tests
{
    [TestClass]
    public class DocumentPaymentValidation : BaseTestClass<DocumentPayment, DocumentPaymentValidator>
    {
		[TestMethod]
		public void CurrentHasChildValidator()
        {
            validator.ShouldHaveChildValidator(dp => dp.Current, typeof(PaymentValidator));
        }
    }
}
