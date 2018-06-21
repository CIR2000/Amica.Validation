using Microsoft.VisualStudio.TestTools.UnitTesting;
using Amica.Validation;
using Amica.Models.Documents;
using FluentValidation.TestHelper;
using Amica.Models;
using Amica.Validation.Tests;

namespace Validation.Tests
{
    [TestClass]
    public class DocumentValidation : BaseTestClass<Document, DocumentValidator>
    {
		[TestMethod]
		public void ReasonIsRequired()
        {
            AssertRequired(d => d.Reason);
        }
		[TestMethod]
		public void NumberHasChildValidator()
        {
            validator.ShouldHaveChildValidator(d => d.Number, typeof(DocumentNumberValidator));
        }
		[TestMethod]
		public void NumberIsRequired()
        {
            challenge.Number = null;
            validator.ShouldHaveValidationErrorFor(d => d.Number, challenge).WithErrorCode("NotNullValidator");
            challenge.Number = new DocumentNumber();
            validator.ShouldNotHaveValidationErrorFor(d => d.Number, challenge);
        }
		[TestMethod]
		public void StatusHasChildValidator()
        {
            validator.ShouldHaveChildValidator(d => d.Status, typeof(DocumentStatusValidator));
        }
		[TestMethod]
		public void StatusIsRequired()
        {
            challenge.Status = null;
            validator.ShouldHaveValidationErrorFor(d => d.Status, challenge).WithErrorCode("NotNullValidator");
            challenge.Status = new Status();  
            validator.ShouldNotHaveValidationErrorFor(d => d.Status, challenge);
        }
		[TestMethod]
		public void CategoryHasChildValidator()
        {
            validator.ShouldHaveChildValidator(d => d.Category, typeof(DocumentCategoryValidator));
        }
		[TestMethod]
		public void CategoryIsRequired()
        {
            challenge.Category = null;
            validator.ShouldHaveValidationErrorFor(d => d.Category, challenge).WithErrorCode("NotNullValidator");
            challenge.Category = new Category();
            validator.ShouldNotHaveValidationErrorFor(d => d.Category, challenge);
        }
		[TestMethod]
		public void PaymentHasChildValidator()
        {
            validator.ShouldHaveChildValidator(d => d.Payment, typeof(DocumentPaymentValidator));
        }
		[TestMethod]
		public void PaymentIsRequired()
        {
            challenge.Payment = null;
            validator.ShouldHaveValidationErrorFor(d => d.Payment, challenge).WithErrorCode("NotNullValidator");
            challenge.Payment = new DocumentPayment();
            validator.ShouldNotHaveValidationErrorFor(d => d.Payment, challenge);
        }
		[TestMethod]
		public void CurrencyHasChildValidator()
        {
            validator.ShouldHaveChildValidator(d => d.Currency, typeof(DocumentCurrencyValidator));
        }
		[TestMethod]
		public void CurrencyIsRequired()
        {
            challenge.Currency = null;
            validator.ShouldHaveValidationErrorFor(d => d.Currency, challenge).WithErrorCode("NotNullValidator");
            challenge.Currency = new DocumentCurrency();
            validator.ShouldNotHaveValidationErrorFor(d => d.Currency, challenge);
        }
		[TestMethod]
		public void BillToHasChildValidator()
        {
            validator.ShouldHaveChildValidator(d => d.BillTo, typeof(BillingAddressValidator));
        }
		[TestMethod]
		public void BillToIsRequired()
        {
            challenge.BillTo = null;
            validator.ShouldHaveValidationErrorFor(d => d.BillTo, challenge).WithErrorCode("NotNullValidator");
            challenge.BillTo = new BillingAddress();
            validator.ShouldNotHaveValidationErrorFor(d => d.BillTo, challenge);
        }
		[TestMethod]
		public void ShipToHasChildValidator()
        {
            validator.ShouldHaveChildValidator(d => d.ShipTo, typeof(ShippingAddressValidator));
        }
		[TestMethod]
		public void ShippingHasChildValidator()
        {
            validator.ShouldHaveChildValidator(d => d.Shipping, typeof(ShippingValidator));
        }
		[TestMethod]
		public void ShippingTermsIsRequiredWhenCategoryIsDeliveryNoteOrShippingInvoice()
        {
            challenge.Shipping = new Shipping { Terms = null };
            challenge.Category = DocumentHelpers.Categories[DocumentCategory.Invoice];
            validator.ShouldNotHaveNestedValidationErrorFor(d => d.Shipping.Terms, challenge);

            challenge.Category = DocumentHelpers.Categories[DocumentCategory.DeliveryNote];
            validator.ShouldHaveNestedValidationErrorFor(d => d.Shipping.Terms, challenge);
            challenge.Shipping.Terms = DocumentHelpers.ShippingTerms[DocumentShippingTerm.DeliveredDutyPaid];
            validator.ShouldNotHaveNestedValidationErrorFor(d => d.Shipping.Terms, challenge);

            challenge.Shipping.Terms = null;
            challenge.Category = DocumentHelpers.Categories[DocumentCategory.ShippingInvoice];
            validator.ShouldHaveNestedValidationErrorFor(d => d.Shipping.Terms, challenge);
            challenge.Shipping.Terms = DocumentHelpers.ShippingTerms[DocumentShippingTerm.DeliveredDutyPaid];
            validator.ShouldNotHaveNestedValidationErrorFor(d => d.Shipping.Terms, challenge);
        }
		[TestMethod]
		public void AgentHasChildValidator()
        {
            validator.ShouldHaveChildValidator(d => d.Agent, typeof(ContactDetailsExValidator));
        }
		[TestMethod]
		public void BankHasChildValidator()
        {
            validator.ShouldHaveChildValidator(d => d.Bank, typeof(BankValidator));
        }
		[TestMethod]
		public void SocialSecurityCollectionHasChildValidator()
        {
            validator.ShouldHaveChildValidator(d => d.SocialSecurityCollection, typeof(SocialSecurityValidator));
        }
		[TestMethod]
		public void VariationCollectionHasChildValidator()
        {
            validator.ShouldHaveChildValidator(d => d.VariationCollection, typeof(VariationValidator));
        }
		[TestMethod]
		public void FeeCollectionHasChildValidator()
        {
            validator.ShouldHaveChildValidator(d => d.FeeCollection, typeof(DocumentFeeValidator));
        }
		[TestMethod]
		public void ItemCollectionHasChildValidator()
        {
            validator.ShouldHaveChildValidator(d => d.ItemCollection, typeof(DocumentItemValidator));
        }
    }
}
