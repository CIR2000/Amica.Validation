using Amica.Models.Documents;
using FluentValidation;

namespace Amica.Validation
{
    public class DocumentItemLotValidator : AbstractValidator<DocumentItemLot>
    {
		public DocumentItemLotValidator()
        {
            RuleFor(fee => fee.Number).NotEmpty();
        }
    }
}
