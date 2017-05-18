using NUnit.Framework;
using Amica.Validation;
using FluentValidation.TestHelper;
using Amica.Models;

namespace Validation.Tests
{
    [TestFixture]
    public class CompanyValidation : BaseTestClass<Company, CompanyValidator>
    {
		[Test]
		public void NameIsRequired()
        {
            AssertRequired(c => c.Name);
        }
    }
}
