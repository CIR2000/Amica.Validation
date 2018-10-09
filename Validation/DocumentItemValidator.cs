using FluentValidation;
using Amica.Models.Documents;

namespace Amica.Validation
{
    public class DocumentItemValidator : AbstractValidator<DocumentItem>
    {
		public DocumentItemValidator()
        {
            RuleFor(x => x.Guid).NotEmpty();
            RuleFor(x => x.Detail)
                .NotNull()
                .SetValidator(new DocumentItemDetailValidator());
            RuleFor(x => x.Order).SetValidator(new OrderReferenceValidator());
            RuleFor(x => x.Vat).SetValidator(new VatValidator());
            RuleFor(x => x.Warehouse).SetValidator(new WarehouseValidator());
            RuleForEach(x => x.VariationCollection).SetValidator(new VariationValidator());
        }
    }
}
