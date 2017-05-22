using NUnit.Framework;
using Amica.Validation;
using Amica.Models.Documents;
using FluentValidation.TestHelper;

namespace Validation.Tests
{
    [TestFixture]
    public class DocumentFeeValidation : BaseTestClass<DocumentFee, DocumentFeeValidator>
    {
		[Test]
		public void VatHasChildValidator()
        {
            validator.ShouldHaveChildValidator(df => df.Vat, typeof(VatValidator));
        }
		[Test]
		public void NameIsRequired()
        {
            AssertRequired(df => df.Name);
        }
		[Test]
		public void AmountCannotBeZero()
        {
            challenge.Amount = 0;
            validator.ShouldHaveValidationErrorFor(df => df.Amount, challenge);
            challenge.Amount = 1;
            validator.ShouldNotHaveValidationErrorFor(df => df.Amount, challenge);
        }
    }
}
