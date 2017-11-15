using FluentValidation;
using Amica.Models.Documents;

namespace Amica.Validation
{
    public class DocumentValidator : AbstractValidator<Document>
    {
		public DocumentValidator()
        {
            RuleFor(d => d.Reason).NotEmpty();
            RuleFor(d => d.Number)
                .NotNull()
                .SetValidator(new DocumentNumberValidator());
            RuleFor(d => d.Status)
                .NotNull()
                .SetValidator(new DocumentStatusValidator());
            RuleFor(d => d.Category)
                .NotNull()
                .SetValidator(new DocumentCategoryValidator());
            RuleFor(d => d.Payment)
                .NotNull()
                .SetValidator(new DocumentPaymentValidator());
            RuleFor(d => d.Currency)
                .NotNull()
                .SetValidator(new DocumentCurrencyValidator());
            RuleFor(d => d.BillTo)
                .NotNull()
                .SetValidator(new BillingAddressValidator());
            RuleFor(d => d.Agent).SetValidator(new ContactDetailsExValidator());
            RuleFor(d => d.ShipTo).SetValidator(new ShippingAddressValidator());
            RuleFor(d => d.Shipping).SetValidator(new ShippingValidator());
            RuleFor(d => d.Shipping.Terms)
                .NotNull()
                .When(d => d.Category?.Code == DocumentCategory.ShippingInvoice || d.Category?.Code == DocumentCategory.DeliveryNote);
            RuleFor(d => d.Bank).SetValidator(new BankValidator());
            RuleFor(d => d.SocialSecurityCollection).SetCollectionValidator(new SocialSecurityValidator());
            RuleFor(d => d.VariationCollection).SetCollectionValidator(new VariationValidator());
            RuleFor(d => d.FeeCollection).SetCollectionValidator(new DocumentFeeValidator());
            RuleFor(d => d.ItemCollection).SetCollectionValidator(new DocumentItemValidator());
        }
    }
}
