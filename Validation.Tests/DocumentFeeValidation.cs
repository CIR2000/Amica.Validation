using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amica.Validation;
using Amica.Models.Documents;
using FluentValidation.TestHelper;

namespace Validation.Tests
{
    [TestClass]
    public class DocumentFeeValidation : BaseTestClass<DocumentFee, DocumentFeeValidator>
    {
		[TestMethod]
		public void VatHasChildValidator()
        {
            validator.ShouldHaveChildValidator(df => df.Vat, typeof(VatValidator));
        }
		[TestMethod]
		public void NameIsRequired()
        {
            AssertRequired(df => df.Name);
        }
		[TestMethod]
		public void AmountCannotBeZero()
        {
            challenge.Amount = 0;
            validator.ShouldHaveValidationErrorFor(df => df.Amount, challenge);
            challenge.Amount = 1;
            validator.ShouldNotHaveValidationErrorFor(df => df.Amount, challenge);
        }
    }
}
