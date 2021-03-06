﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amica.Validation;
using Amica.Models;

namespace Validation.Tests
{
    [TestClass]
    public class ShippingAddressValidation : BaseTestClass<ShippingAddress, ShippingAddressValidator>
    {
        [TestMethod]
        public void NameIsRequired()
        {
            AssertRequired(c => c.Name);
        }
		[TestMethod]
		public void MailMustBeValid()
        {
            AssertValidEmail(c => c.Mail);
        }
		[TestMethod]
		public void PecMailMustBeValid()
        {
            AssertValidEmail(c => c.PecMail);
        }

    }
}
