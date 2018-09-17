using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amica.Validation;
using FluentValidation.TestHelper;
using Amica.Models;

namespace Validation.Tests
{
    [TestClass]
    public class MailSettingsValidation : BaseTestClass<MailSettings, MailSettingsValidator>
    {
		[TestMethod]
		public void AddressHasChildValidator() {
            validator.ShouldHaveChildValidator(c => c.Template, typeof(MailTemplateValidator));
        }
    }
}
