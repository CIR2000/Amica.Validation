using System.Collections.Generic;
using Amica.Models;
using Amica.Validation;
using FluentValidation;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Validation.Tests {
    [TestClass]
    public class ProductPriceValidation : BaseTestClass<ProductPrice, ProductPriceValidator> {
        [TestMethod]
        public void PriceListIdIsRequired() 
        {
             AssertRequired(x => x.PriceListId);
        }
        [TestMethod]
        public void DiscountCannotBeNull() 
        {
            challenge.Discount = null;
            validator.ShouldHaveValidationErrorFor(x => x.Discount, challenge);

            challenge.Discount = new List<float>();
            validator.ShouldNotHaveValidationErrorFor(x => x.Discount, challenge);
        }
    }
}