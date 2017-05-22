using FluentValidation;
using Amica.Models.Documents;

namespace Amica.Validation
{
    public class DocumentItemDetailValidator : AbstractValidator<DocumentItemDetail>
    {
		public DocumentItemDetailValidator()
        {
            RuleFor(d => d.Description).NotEmpty();
            RuleFor(d => d.Lot).SetValidator(new DocumentItemLotValidator());
            RuleFor(d => d.Size).SetValidator(new DocumentItemSizeValidator());
        }
    }
}
