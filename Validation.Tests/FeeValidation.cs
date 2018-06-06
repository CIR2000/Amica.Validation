using NUnit.Framework;
using Amica.Validation;
using Amica.Models;

namespace Validation.Tests
{
    [TestFixture]
    public class FeeValidation : BaseTestClass<Fee, FeeValidator>
    {
		[Test]
		public void NameIsRequired()
        {
            AssertRequired(c => c.Name);
        }
		[Test]
		public void VatIdIsValidObjectId()
        {
            AssertIsValidObjectId<Fee>(x => x.VatId);
        }
    }
}
