using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amica.Validation;
using Amica.Models;

namespace Validation.Tests
{
    [TestClass]
    public class MailTemplateValidation : BaseTestClass<MailTemplate, MailTemplateValidator>
    {
		[TestMethod]
		public void NameIsRequired()
        {
            AssertRequired(x => x.Name);
        }
    }
}
