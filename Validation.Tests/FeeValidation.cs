using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amica.Validation;
using Amica.Models;

namespace Validation.Tests
{
    [TestClass]
    public class FeeValidation : BaseTestClass<Fee, FeeValidator>
    {
		[TestMethod]
		public void NameIsRequired()
        {
            AssertRequired(c => c.Name);
        }
		[TestMethod]
		public void VatIdIsValidObjectId()
        {
            AssertIsValidObjectId<Fee>(x => x.VatId);
        }
    }
}
