using Amica.Models.Documents;
using FluentValidation;

namespace Amica.Validation
{
    public class DocumentItemSizeValidator : AbstractValidator<DocumentItemSize>
    {
		public DocumentItemSizeValidator()
        {
            RuleFor(fee => fee.Name).NotEmpty();
            RuleFor(fee => fee.Number).NotEmpty();
        }
    }
}
