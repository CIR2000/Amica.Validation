using System.Collections.Generic;
using Amica.Models;
using Amica.Validation;
using FluentValidation;
using FluentValidation.TestHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Validation.Tests
{
    [TestClass]
    public class ProductValidation : BaseTestClass<Product, ProductValidator>
    {
        [TestMethod]
        public void NameAndDescriptionAreMutuallyRequired()
        {
            challenge.Name = null;
            challenge.Description = null;
            validator.ShouldHaveValidationErrorFor(p => p.Name, challenge);
            validator.ShouldHaveValidationErrorFor(p => p.Description, challenge);

            challenge.Name = string.Empty;
            challenge.Description = null;
            validator.ShouldHaveValidationErrorFor(p => p.Name, challenge);
            validator.ShouldHaveValidationErrorFor(p => p.Description, challenge);

            challenge.Name = null;
            challenge.Description = string.Empty;
            validator.ShouldHaveValidationErrorFor(p => p.Name, challenge);
            validator.ShouldHaveValidationErrorFor(p => p.Description, challenge);

            challenge.Name = string.Empty;
            challenge.Description = string.Empty;
            validator.ShouldHaveValidationErrorFor(p => p.Name, challenge);
            validator.ShouldHaveValidationErrorFor(p => p.Description, challenge);

            challenge.Name = "name";
            challenge.Description = null;
            validator.ShouldNotHaveValidationErrorFor(p => p.Name, challenge);
            validator.ShouldNotHaveValidationErrorFor(p => p.Description, challenge);

            challenge.Name = "name";
            challenge.Description = string.Empty;
            validator.ShouldNotHaveValidationErrorFor(p => p.Name, challenge);
            validator.ShouldNotHaveValidationErrorFor(p => p.Description, challenge);

            challenge.Name = null;
            challenge.Description = "description";
            validator.ShouldNotHaveValidationErrorFor(p => p.Name, challenge);
            validator.ShouldNotHaveValidationErrorFor(p => p.Description, challenge);

            challenge.Name = string.Empty;
            challenge.Description = "description";
            validator.ShouldNotHaveValidationErrorFor(p => p.Name, challenge);
            validator.ShouldNotHaveValidationErrorFor(p => p.Description, challenge);
        }

        [TestMethod]
        public void PricesCannotBeNull()
        {
            challenge.Prices = null;
            validator.ShouldHaveValidationErrorFor(x => x.Prices, challenge);

            challenge.Prices = new List<ProductPrice>();
            validator.ShouldNotHaveValidationErrorFor(x => x.Prices, challenge);
        }

        [TestMethod]
        public void PricesHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.Prices, typeof(ProductPriceValidator));
        }

        [TestMethod]
        public void InentoryHasChildValidator()
        {
            validator.ShouldHaveChildValidator(x => x.Inventory, typeof(ProductInventoryValidator));
        }
    }
}