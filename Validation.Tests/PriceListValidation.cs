using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amica.Validation;
using Amica.Models;
using FluentValidation.TestHelper;

namespace Validation.Tests
{
    [TestClass]
    public class PriceListValidation : BaseTestClass<PriceList, PriceListValidator>
    {
        [TestMethod]
        public void NameIsRequired()
        {
            AssertRequired(x => x.Name);
        }
        [TestMethod]
        public void TypeIsInEnum()
        {
            challenge.Type = (PriceListType)999;
            validator.ShouldHaveValidationErrorFor(x => x.Type, challenge);
            challenge.Type = PriceListType.Sell;
            validator.ShouldNotHaveValidationErrorFor(x => x.Type, challenge);
        }
        [TestMethod]
        public void CurrencyCodeIsRequired()
        {
            AssertRequired(x => x.CurrencyCode);
        }
        [TestMethod]
        public void CurrencyCodeIsValid()
        {
            challenge.CurrencyCode = "Not really";
            validator.ShouldHaveValidationErrorFor(x => x.CurrencyCode, challenge);
            challenge.CurrencyCode = CurrencyHelpers.Currencies["USD"].Code;
            validator.ShouldNotHaveValidationErrorFor(x => x.CurrencyCode, challenge);
        }
        [TestMethod]
        public void PricesAreSetIsInEnum()
        {
            challenge.PricesAreSet = (PriceListPricesAreSet)999;
            validator.ShouldHaveValidationErrorFor(x => x.PricesAreSet, challenge);
            challenge.PricesAreSet = PriceListPricesAreSet.GlobalMarkupOnAverageCost;
            validator.ShouldNotHaveValidationErrorFor(x => x.PricesAreSet, challenge);
        }
    }
}
