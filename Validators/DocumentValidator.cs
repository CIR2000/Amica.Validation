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
        }
    }
}
