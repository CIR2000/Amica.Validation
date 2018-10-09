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
            RuleForEach(d => d.SocialSecurityCollection).SetValidator(new SocialSecurityValidator());
            RuleForEach(d => d.VariationCollection).SetValidator(new VariationValidator());
            RuleForEach(d => d.FeeCollection).SetValidator(new DocumentFeeValidator());
            RuleForEach(d => d.ItemCollection).SetValidator(new DocumentItemValidator());
        }
    }
}
