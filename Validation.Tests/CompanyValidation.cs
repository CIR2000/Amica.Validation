using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amica.Validation;
using Amica.Models.Company;
using FluentValidation.TestHelper;

namespace Validation.Tests
{
    [TestClass]
    public class CompanyValidation : BaseTestClass<Company, CompanyValidator>
    {
		[TestMethod]
		public void NameIsRequired()
        {
            AssertRequired(c => c.Name);
        }
		[TestMethod]
		public void FiscalProfileHasChildValidator() {
            validator.ShouldHaveChildValidator(c => c.FiscalProfile, typeof(FiscalProfileValidator));
        }
    }
}
