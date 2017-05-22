using NUnit.Framework;
using Amica.Validation;
using Amica.Models.Documents;
using FluentValidation.TestHelper;
using Amica.Models;
using Amica.Validation.Tests;

namespace Validation.Tests
{
    [TestFixture]
    public class DocumentValidation : BaseTestClass<Document, DocumentValidator>
    {
		[Test]
		public void ReasonIsRequired()
        {
            AssertRequired(d => d.Reason);
        }
		[Test]
		public void NumberHasChildValidator()
        {
            validator.ShouldHaveChildValidator(d => d.Number, typeof(DocumentNumberValidator));
        }
		[Test]
		public void NumberIsRequired()
        {
            challenge.Number = null;
            validator.ShouldHaveValidationErrorFor(d => d.Number, challenge).WithErrorCode("notnull_error");
            challenge.Number = new DocumentNumber();
            validator.ShouldNotHaveValidationErrorFor(d => d.Number, challenge);
        }
		[Test]
		public void StatusHasChildValidator()
        {
            validator.ShouldHaveChildValidator(d => d.Status, typeof(DocumentStatusValidator));
        }
		[Test]
		public void StatusIsRequired()
        {
            challenge.Status = null;
            validator.ShouldHaveValidationErrorFor(d => d.Status, challenge).WithErrorCode("notnull_error");
            challenge.Status = new Status();  
            validator.ShouldNotHaveValidationErrorFor(d => d.Status, challenge);
        }
		[Test]
		public void CategoryHasChildValidator()
        {
            validator.ShouldHaveChildValidator(d => d.Category, typeof(DocumentCategoryValidator));
        }
		[Test]
		public void CategoryIsRequired()
        {
            challenge.Category = null;
            validator.ShouldHaveValidationErrorFor(d => d.Category, challenge).WithErrorCode("notnull_error");
            challenge.Category = new Category();
            validator.ShouldNotHaveValidationErrorFor(d => d.Category, challenge);
        }
		[Test]
		public void PaymentHasChildValidator()
        {
            validator.ShouldHaveChildValidator(d => d.Payment, typeof(DocumentPaymentValidator));
        }
		[Test]
		public void PaymentIsRequired()
        {
            challenge.Payment = null;
            validator.ShouldHaveValidationErrorFor(d => d.Payment, challenge).WithErrorCode("notnull_error");
            challenge.Payment = new DocumentPayment();
            validator.ShouldNotHaveValidationErrorFor(d => d.Payment, challenge);
        }
		[Test]
		public void CurrencyHasChildValidator()
        {
            validator.ShouldHaveChildValidator(d => d.Currency, typeof(DocumentCurrencyValidator));
        }
		[Test]
		public void CurrencyIsRequired()
        {
            challenge.Currency = null;
            validator.ShouldHaveValidationErrorFor(d => d.Currency, challenge).WithErrorCode("notnull_error");
            challenge.Currency = new DocumentCurrency();
            validator.ShouldNotHaveValidationErrorFor(d => d.Currency, challenge);
        }
		[Test]
		public void BillToHasChildValidator()
        {
            validator.ShouldHaveChildValidator(d => d.BillTo, typeof(BillingAddressValidator));
        }
		[Test]
		public void BillToIsRequired()
        {
            challenge.BillTo = null;
            validator.ShouldHaveValidationErrorFor(d => d.BillTo, challenge).WithErrorCode("notnull_error");
            challenge.BillTo = new BillingAddress();
            validator.ShouldNotHaveValidationErrorFor(d => d.BillTo, challenge);
        }
		[Test]
		public void ShipToHasChildValidator()
        {
            validator.ShouldHaveChildValidator(d => d.ShipTo, typeof(ShippingAddressValidator));
        }
		[Test]
		public void ShippingHasChildValidator()
        {
            validator.ShouldHaveChildValidator(d => d.Shipping, typeof(ShippingValidator));
        }
		[Test]
		public void ShippingTermsIsRequiredWhenCategoryIsDeliveryNoteOrShippingInvoice()
        {
            challenge.Shipping = new Shipping { Terms = null };
            challenge.Category = DocumentHelpers.Categories[DocumentCategory.Invoice];
            validator.ShouldNotHaveNestedValidationErrorFor(d => d.Shipping.Terms, challenge);

            challenge.Category = DocumentHelpers.Categories[DocumentCategory.DeliveryNote];
            validator.ShouldHaveNestedValidationErrorFor(d => d.Shipping.Terms, challenge);
            challenge.Shipping.Terms = DocumentHelpers.TransportTerms[DocumentShippingTerm.DeliveredDutyPaid];
            validator.ShouldNotHaveNestedValidationErrorFor(d => d.Shipping.Terms, challenge);

            challenge.Shipping.Terms = null;
            challenge.Category = DocumentHelpers.Categories[DocumentCategory.ShippingInvoice];
            validator.ShouldHaveNestedValidationErrorFor(d => d.Shipping.Terms, challenge);
            challenge.Shipping.Terms = DocumentHelpers.TransportTerms[DocumentShippingTerm.DeliveredDutyPaid];
            validator.ShouldNotHaveNestedValidationErrorFor(d => d.Shipping.Terms, challenge);
        }
		[Test]
		public void AgentHasChildValidator()
        {
            validator.ShouldHaveChildValidator(d => d.Agent, typeof(ContactDetailsExValidator));
        }
		[Test]
		public void BankHasChildValidator()
        {
            validator.ShouldHaveChildValidator(d => d.Bank, typeof(BankValidator));
        }
		[Test]
		public void SocialSecurityCollectionHasChildValidator()
        {
            validator.ShouldHaveChildValidator(d => d.SocialSecurityCollection, typeof(SocialSecurityValidator));
        }
		[Test]
		public void VariationCollectionHasChildValidator()
        {
            validator.ShouldHaveChildValidator(d => d.VariationCollection, typeof(VariationValidator));
        }
		[Test]
		public void FeeCollectionHasChildValidator()
        {
            validator.ShouldHaveChildValidator(d => d.FeeCollection, typeof(DocumentFeeValidator));
        }
		[Test]
		public void ItemCollectionHasChildValidator()
        {
            validator.ShouldHaveChildValidator(d => d.ItemCollection, typeof(DocumentItemValidator));
        }
    }
}
